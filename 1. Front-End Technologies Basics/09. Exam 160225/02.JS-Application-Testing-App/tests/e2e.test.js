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

let bookTitle = "";

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

            await page.locator('//input[@type="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.locator('//input[@name="conf-pass"]').fill(user.confirmPass);
            await page.click('//button[@type="submit"]');
            

            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("Login with valid credentials functionality", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");

            await page.locator('//input[@type="text"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
        test("Logout from the application functionality", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");
            
            await page.locator('//input[@type="text"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await page.click('//a[text()="Logout"]');
            await expect(page.locator('//a[text()="Login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        })
    });

    describe("navbar", () => {
        test("Navigation for Logged-In User functionality", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");

            await page.locator('//input[@type="text"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[text()="Home"]')).toBeVisible();
            await expect(page.locator('//a[text()="Collection"]')).toBeVisible();
            await expect(page.locator('//a[text()="Search"]')).toBeVisible();
            await expect(page.locator('//a[text()="Create Book"]')).toBeVisible();
            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();

            await expect(page.locator('//a[text()="Login"]')).toBeHidden();
            await expect(page.locator('//a[text()="Register"]')).toBeHidden();
        }); 

        test("Navigation for Guest User functionality", async () => {
            await page.goto(host);
            
            await expect(page.locator('//a[text()="Home"]')).toBeVisible();
            await expect(page.locator('//a[text()="Collection"]')).toBeVisible();
            await expect(page.locator('//a[text()="Search"]')).toBeVisible();
            await expect(page.locator('//a[text()="Login"]')).toBeVisible();
            await expect(page.locator('//a[text()="Register"]')).toBeVisible();

            await expect(page.locator('//a[text()="Create Book"]')).toBeHidden();
            await expect(page.locator('//a[text()="Logout"]')).toBeHidden();
        });
    });

    describe("CRUD", () => {
        beforeEach(async() => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("//form");

            await page.locator('//input[@type="text"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');
        });

        test("Create a book functionality", async () => {
            await page.click('//a[text()="Create Book"]');
            await page.waitForSelector("//form");

            let random = Math.floor(Math.random() * 10000);
            bookTitle = `BookTitle_${random}`;
                        
            await page.locator('//input[@id="title"]').fill(bookTitle);
            await page.locator('//input[@id="coverImage"]').fill("/images/random_cover.webp");
            await page.locator('//input[@id="year"]').fill("2025");
            await page.locator('//input[@id="author"]').fill("J.K. Rowling");
            await page.locator('//input[@id="genre"]').fill("Fantasy");
            await page.locator('//textarea[@class="description"]').fill("This is a great book to read");
            await page.click('//button[@class="save-btn"]');

            await expect(page.locator('//div[@class="book-details"]//h2', {hasText:bookTitle})).toHaveCount(1);
            expect(page.url()).toBe(host + '/collection');
        });
        
        test("Edit a book functionality", async () => {
            await page.click('//a[text()="Search"]');
            await page.fill('//input[@name="search"]', bookTitle);
            await page.click('//button[@type="submit"]');

            //await page.click('//section[@class="search-results"]//ul//li//following-sibling::a');
            //await page.click('#searchPage > section > ul > li > a');
            await page.click('body > header > nav > a:nth-child(5)');
                       
            await page.click('//a[@class="edit-btn"]');
            //body > main > div > div > div > div > a.edit-btn
            await page.waitForSelector("//form");

            bookTitle = `${bookTitle}_edited`;
            await page.locator('//input[@id="title"]').fill(bookTitle);
            await page.click('//div[@class="book-details"]//button[@class="save-btn"]');
           
            await expect(page.locator('//div[@class="book-info"//h2', {hasText:bookTitle})).toHaveCount(1);
        });

        test("Delete a book functionality", async () => {
            await page.click('//a[text()="Search"]');
            await page.fill('//input[@name="search"]', bookTitle);
            await page.click('//button [@type="submit"]');

            //await page.click('//section[@class="search-results"]//ul//li//following-sibling::a');
            await page.click('body > header > nav > a:nth-child(5)');
            await page.click('//a[@class="delete-btn"]');
                   
            await expect(page.locator('//div[@class="book-info"]//h2', {hasText:bookTitle})).toHaveCount(0);
            expect(page.url()).toBe(host + '/collection');
        });
    });
});