const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email : "",
    password : "123456",
    confirmPass : "123456",
};

let albumName = "";

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    
    describe("authentication", () => {
        test("Register with valid credentials functionality", async() => {
            await page.goto(host);
            await page.click('//a[text()="Register"]');
            await page.waitForSelector("//form");

            let random = Math.floor(Math.random() * 1000);
            user.email = `email_${random}@gmail.com`;

            await page.locator('//input[@id="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.locator('//input[@id="conf-pass"]').fill(user.confirmPass);
            await page.click('//button[@class="register"]');
            

            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("Login with valid credentials functionality", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");

            await page.locator('//input[@id="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.click('//button[@class="login"]');

            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("Logout from the application functionality", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");
            
            await page.locator('//input[@id="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.click('//button[@class="login"]');

            await page.click('//a[text()="Logout"]');
            await expect(page.locator('//a[text()="Login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
    });

    describe("navbar", () => {
        test("Navigation for Logged-In User functionality", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");
            
            await page.locator('//input[@id="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.click('//button[@class="login"]');

            await expect(page.locator('//a[text()="Home"]')).toBeVisible();
            await expect(page.locator('//a[text()="Catalog"]')).toBeVisible();
            await expect(page.locator('//a[text()="Search"]')).toBeVisible();
            await expect(page.locator('//a[text()="Create Album"]')).toBeVisible();
            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();

            await expect(page.locator('//a[text()="Login"]')).toBeHidden();
            await expect(page.locator('//a[text()="Register"]')).toBeHidden();
        });

        test("Navigation for Guest User functionality", async () => {
            await page.goto(host);
            
            await expect(page.locator('//a[text()="Home"]')).toBeVisible();
            await expect(page.locator('//a[text()="Catalog"]')).toBeVisible();
            await expect(page.locator('//a[text()="Login"]')).toBeVisible();
            await expect(page.locator('//a[text()="Register"]')).toBeVisible();

            await expect(page.locator('//a[text()="Create Album"]')).toBeHidden();
            await expect(page.locator('//a[text()="Logout"]')).toBeHidden();
        });
    });

    describe("CRUD", () => {
        beforeEach(async() => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");

            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.click('//button[text()="Login"]');
        });

        test("Create an album functionality", async () => {
            await page.click('//a[text()="Create Album"]');
            await page.waitForSelector("//form");

            let random = Math.floor(Math.random() * 10000);
            albumName = `AlbumName_${random}`;
                        
            await page.locator('//input[@id="name"]').fill(albumName);
            await page.locator('//input[@id="imgUrl"]').fill("/images/musicIcons.webp");
            await page.locator('//input[@id="price"]').fill("20");
            await page.locator('//input[@id="releaseDate"]').fill("01-01-2000");
            await page.locator('//input[@id="artist"]').fill("Krisko Beats");
            await page.locator('//input[@id="genre"]').fill("hip hop");
            await page.locator('//textarea[@class="description"]').fill("hip hop");
            await page.click('//button[@class="add-album"]');

            await expect(page.locator('//div[@class="card-box"]//p[@class="name"]', {hasText:albumName})).toHaveCount(1);
            expect(page.url()).toBe(host + '/catalog');
        });

        test("Edit an album functionality", async () => {
            await page.click('//a[text()="Search"]');
            await page.fill('//input[@id="search-input"]', albumName);
            await page.click('//button [@class="button-list"]');

            await page.click('//a[@id="details"]');
            await page.click('//a[@class="edit"]');
            await page.waitForSelector("//form");

            albumName = `${albumName}_edited`;
            await page.locator('//input[@id="name"]').fill(albumName);
            await page.click('//button[@class="edit-album"]');
           
            await expect(page.locator('//h1', {hasText:albumName})).toHaveCount(1);
        });

        test("Delete an album functionality", async () => {
            await page.click('//a[text()="Search"]');
            await page.fill('//input[@id="search-input"]', albumName);
            await page.click('//button [@class="button-list"]');

            await page.click('//a[@id="details"]');
            await page.click('//a[@class="remove"]');
                   
            await expect(page.locator('//div[@class="card-box"]//p[@class="name"]', {hasText:albumName})).toHaveCount(0);
            expect(page.url()).toBe(host + '/catalog');
        });
    });
});