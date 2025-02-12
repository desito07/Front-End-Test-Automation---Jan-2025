const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context; 
let page; 

let user = {
    email: "", 
    password: "123456",
    confrimPassword: "123456"
}

let game = {
    title: "",
    category: "", 
    id: "",
    maxLevel: "99",
    imageUrl: "https://w0.peakpx.com/wallpaper/100/609/HD-wallpaper-grand-theft-auto-v-game-gta-logo-pc-rockstar.jpg",
    summary: "This is a great game"
}

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

    describe("Authentication tests", () => {
        test("Register with valid data", async() => {
            await page.goto(host);
            await page.click('//a[text()="Register"]');
            await page.waitForSelector("form");

            let random = Math.floor(Math.random() * 1000);
            user.email = `abv_${random}@abv.bg`;

            await page.fill('//input[@id="email"]', user.email);
            await page.fill('//input[@id="register-password"]', user.password);
            await page.fill('//input[@id="confirm-password"]', user.confrimPassword);
            await page.click('//input[@type="submit"]');

            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("Register with empty fields", async() => {
            await page.goto(host + '/');
            await page.click('//a[text()="Register"]');
            await page.waitForSelector("form");

            page.on('dialog', async dialog => {
                expect(dialog.message()).toBe("No empty fields are allowed and confirm password has to match password!");
                await dialog.accept();
            });

            await page.click('//input[@type="submit"]');
            expect(page.url()).toBe(host + '/register');
        });

        test("Login with valid crdentials", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("form");

            await page.fill('//input[@type="email"]', user.email);
            await page.fill('//input[@type="password"]', user.password);
            await page.click('//input[@type="submit"]');

            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("Login with empty fields", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("form");

            await page.click('//input[@type="submit"]');

            page.on('dialog', async dialog => {
                expect(dialog.message()).toBe("Unable to log in!");
                await dialog.accept();
            });


            await expect(page.locator('//a[text()="Login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/login');
        });

        test("Logout from the application", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("form");

            await page.fill('//input[@type="email"]', user.email);
            await page.fill('//input[@type="password"]', user.password);
            await page.click('//input[@type="submit"]');

            await page.click('//a[text()="Logout"]');
            await expect(page.locator('//a[text()="Login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

    });

    describe("Navbar tests", () => {
        test("Navigation Bar for Logged-In User", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("form");

            await page.fill('//input[@type="email"]', user.email);
            await page.fill('//input[@type="password"]', user.password);
            await page.click('//input[@type="submit"]');

            await expect(page.locator('//a[text()="All games"]')).toBeVisible();
            await expect(page.locator('//a[text()="Create Game"]')).toBeVisible();
            await expect(page.locator('//a[text()="Logout"]')).toBeVisible();

            await expect(page.locator('//a[text()="Login"]')).toBeHidden();
            await expect(page.locator('//a[text()="Register"]')).toBeHidden();
        });

        test("Navigation Bar for Guest User", async () => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("form");

            await expect(page.locator('//a[text()="All games"]')).toBeVisible();
            await expect(page.locator('//a[text()="Create Game"]')).toBeHidden();
            await expect(page.locator('//a[text()="Logout"]')).toBeHidden();

            await expect(page.locator('//a[text()="Login"]')).toBeVisible();
            await expect(page.locator('//a[text()="Register"]')).toBeVisible();
        });
    });

    describe("CRUD tests", async() => {
        beforeEach(async() => {
            await page.goto(host);
            await page.click('//a[text()="Login"]');
            await page.waitForSelector("form");

            await page.fill('//input[@type="email"]', user.email);
            await page.fill('//input[@type="password"]', user.password);
            await page.click('//input[@type="submit"]');
        });
        test("Create does NOT work with empty fields", async () => {
            await page.click('//a[@href="/create"]');
            await page.waitForSelector("form");
            
            page.on('dialog', async dialog => {
                expect(dialog.message()).toBe("All fields are required!");
                await dialog.accept();
            });
            
            await page.click('//input[@type="submit"]');

            expect(page.url()).toBe(host + '/create');
        });

        test("Create a game with valid input values", async () => {
            let random = Math.floor(Math.random() * 1000);
            game.title = `Game title ${random}`;
            game.category =  `Game category ${random}`;
                        
            await page.click('//a[@href="/create"]');
            await page.waitForSelector("form");
            
            await page.fill('//input[@id="title"]', game.title);
            await page.fill('//input[@id="category"]', game.category);
            await page.fill('//input[@id="maxLevel"]', game.maxLevel);
            await page.fill('//input[@id="imageUrl"]', game.imageUrl);
            await page.fill('//textarea[@id="summary"]', game.summary);
            await page.click('//input[@type="submit"]');

            await expect(page.locator(`//div[@class="game"]//h3[text()="${game.title}"]`)).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test("Correct details when open a game that is created by me", async() => {
            await page.goto(host + "/catalog");
            await page.click(`//div[@class="allGames"]//h2[text()='${game.title}']//following-sibling::a`);
            game.id = page.url().split('/').pop();

            await expect(page.locator('//a[text()="Edit"]')).toBeVisible();
            await expect(page.locator('//a[text()="Delete"]')).toBeVisible();
        });

        test("Non owners cannot see Edit and Delete buttons", async() => {
            await page.goto(host + "/catalog");
            await page.click('//div[@class="allGames"]//h2[text()="MineCraft"]/parent::div//a');
            
            await expect(page.locator('//a[text()="Edit"]')).toBeHidden();
            await expect(page.locator('//a[text()="Delete"]')).toBeHidden();
        });

        test("Edit with valid data successfully modifies the game", async() => {
            await page.goto(host + "/catalog");
            await page.click(`//div[@class="allGames"]//h2[text()='${game.title}']//following-sibling::a`);
            await page.click('//a[text()="Edit"]');

            await page.waitForSelector("form");

            game.title = `${game.title}_edited`;
            await page.fill('//input[@id="title"]', game.title);

            await page.click('//input[@type="submit"]');

            await expect(page.locator(`//div[@class="game-header"]//h1[text()='${game.title}']`)).toBeVisible();
            expect (page.url()).toBe(host + `/details/${game.id}`);
        });

        test("Successfully delete the game", async () => {

            await page.goto(host + "/catalog");
            await page.click(`//div[@class="allGames"]//h2[text()='${game.title}']//following-sibling::a`);
            await page.click('//a[text()="Delete"]');

            await expect(page.locator(`//div[@class="game"]//h3[text()='${game.title}']`)).toBeHidden();
            expect (page.url()).toBe(host + "/");
        });
    });
   
    describe("Home Page tests", () => {
        test("Correct data on home page", async() => {
            await page.goto(host);
            await expect(page.locator('//div[@class="welcome-message"]//h2')).toHaveText("ALL new games are");
            await expect(page.locator('//div[@class="welcome-message"]//h3')).toHaveText("Only in GamesPlay");
            await expect(page.locator('//div[@id="home-page"]//h1')).toHaveText("Latest Games");

            const divGames = await page.locator('//div[@class="game"]').all();
            expect(divGames.length).toBeGreaterThanOrEqual(3);
        });
    });
});