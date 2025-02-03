const { test, expect} = require('@playwright/test');

// Verify 'All Books' link is visible
test('Verify "All Books" link is visible', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const allBooksLink = await page.$(`a[href="/catalog"]`);
    const isLinkVisible = await allBooksLink.isVisible();
    expect(isLinkVisible).toBe(true);
});

// Verify That the "Login" Button Is Visible
test('Verify "Login" button is  visible', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const loginButton = await page.$(`a[href="/login"]`);
    const isLoginButtonVisible = await loginButton.isVisible();
    expect(isLoginButtonVisible).toBe(true);
});

//Verify That the "Register" Button Is Visible
test('Verify "Register" button is  visible', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const registerButton = await page.$(`a[href="/register"]`);
    const isRegisterButtonVisible = await registerButton.isVisible();
    expect(isRegisterButtonVisible).toBe(true);
});

//Verify "All Books" link is visible after user login
test('Verify "All Books" link is visible after user login', async ({ page }) => {
    await page.goto('http://localhost:3000');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');
    const allBooksLinkAfterLogin = await page.$(`a[href="/catalog"]`);
    const isAllBooksLinkVisible = await allBooksLinkAfterLogin.isVisible();
    expect(isAllBooksLinkVisible).toBe(true);
});