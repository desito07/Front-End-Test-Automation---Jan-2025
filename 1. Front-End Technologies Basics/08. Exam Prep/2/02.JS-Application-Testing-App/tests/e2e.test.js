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

let petName = "";

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
            user.email = `email_${random}@yahoo.com`;

            await page.locator('//input[@id="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.locator('//input[@id="repeatPassword"]').fill(user.confirmPass);
            await page.click('//button[@type="submit"]');
            
            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("Login with valid credentials functionality", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");

            await page.locator('//input[@id="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("Logout from the application functionality", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");
            
            await page.locator('//input[@id="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await page.click('//a[text()="Logout"]');
            await expect(page.locator('//a[text()="Login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
    })

    describe("navbar", () => {
        test("Navigation for Logged-In User functionality", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");
            
            await page.locator('//input[@id="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[text()="Home"]')).toBeVisible();
            await expect(page.locator('//a[text()="Dashboard"]')).toBeVisible();
            await expect(page.locator('//a[text()="Create Postcard"]')).toBeVisible();
            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();
            
            await expect(page.locator('//a[text()="Login"]')).toBeHidden();
            await expect(page.locator('//a[text()="Register"]')).toBeHidden();
        });

        test("Navigation for Guest User functionality", async () => {
            await page.goto(host);
            
            await expect(page.locator('//a[text()="Home"]')).toBeVisible();
            await expect(page.locator('//a[text()="Dashboard"]')).toBeVisible();
            await expect(page.locator('//a[text()="Login"]')).toBeVisible();
            await expect(page.locator('//a[text()="Register"]')).toBeVisible();

            await expect(page.locator('//a[text()="Create Postcard"]')).toBeHidden();
            await expect(page.locator('//a[text()="Logout"]')).toBeHidden();
        });
    });

    describe("CRUD", () => {
        beforeEach(async() => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");

            await page.locator('//input[@id="email"]').fill(user.email);
            await page.locator('//input[@id="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');
        })
        test("Create a postcard functionality", async () => {
            await page.click('//a[text()="Create Postcard"]');
            await page.waitForSelector("//form");

            let random = Math.floor(Math.random() * 10000);
            petName = `PetName${random}`;
                        
            await page.locator('//input[@id="name"]').fill(petName);
            await page.locator('//input[@name="breed"]').fill("French Queen");
            await page.locator('//input[@id="age"]').fill("5");
            await page.locator('//input[@id="weight"]').fill("10");
            await page.locator('//input[@id="image"]').fill("/images/cat-create.jpg");
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//div[@class="animals-board"]//h2[@class="name"]', {hasText:petName})).toHaveCount(1);
            expect(page.url()).toBe(host + '/catalog');
        });
        test("Edit a postcard functionality", async () => {
            await page.click('//a[text()="Dashboard"]');
            await page.click('//a[@class="btn"]');
            await page.click('//a[@class="edit"]');
            await page.waitForSelector("//form");

            petName = `${petName}_edited`;
            await page.locator('//input[@id="name"]').fill(petName);
            await page.click('//button[@type="submit"]');
           
            await expect(page.locator('//h1', {hasText:petName})).toHaveCount(1);
        });

        test("Delete a postcard functionality", async () => {
            await page.click('//a[text()="Dashboard"]');
            await page.click('//a[@class="btn"]');

            await page.click('//a[@class="remove"]');
                   
            await expect(page.locator('//div[@class="animals-board"]//h2[@class="name"]', {hasText:petName})).toHaveCount(0);
            expect(page.url()).toBe(host + '/catalog');
        });
    });
});