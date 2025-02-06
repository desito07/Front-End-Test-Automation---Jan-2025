const { test, expect} = require('@playwright/test');

// Verify 'All Books' link is visible
test('Verify "All Books" link is visible', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const allBooksLink = await page.locator('a[href="/catalog"]');
    const isLinkVisible = await allBooksLink.isVisible();
    expect(isLinkVisible).toBe(true);
});

// Verify That the "Login" Button Is Visible
test('Verify "Login" button is  visible', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const loginButton = await page.locator('a[href="/login"]');
    const isLoginButtonVisible = await loginButton.isVisible();
    expect(isLoginButtonVisible).toBe(true);
});

//Verify That the "Register" Button Is Visible
test('Verify "Register" button is  visible', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const registerButton = await page.locator('a[href="/register"]');
    const isRegisterButtonVisible = await registerButton.isVisible();
    expect(isRegisterButtonVisible).toBe(true);
});

//Verify "All Books" link is visible after user login
test('Verify "All Books" link is visible after user login', async ({ page }) => {
    await page.goto('http://localhost:3000/login');
    await page.locator('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');
    const allBooksLinkAfterLogin = await page.locator('a[href="/catalog"]');
    const isAllBooksLinkVisible = await allBooksLinkAfterLogin.isVisible();
    expect(isAllBooksLinkVisible).toBe(true);
});

//Verify buttons are visible when user is logged in
test.only('Verify buttons are visible when user is logged in', async ({ page }) => {
    await page.goto('http://localhost:3000/login');

    await page.locator('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    //await expect(page.locator('//div[id="user"]')).toBeVisible();
    const emailElement = await page.locator('//div[id="user"]//span');
    const isEmailButtonVisible = await emailElement.isVisible();
    expect(isEmailButtonVisible).toBe(true);
});
