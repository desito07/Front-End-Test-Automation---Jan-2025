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
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');
    const allBooksLinkAfterLogin = await page.locator('a[href="/catalog"]');
    const isAllBooksLinkVisible = await allBooksLinkAfterLogin.isVisible();
    expect(isAllBooksLinkVisible).toBe(true);
});

//Verify buttons are visible when user is logged in
test('Verify buttons are visible when user is logged in', async ({ page }) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    const emailElement = await page.locator('//div[@id="user"]//span');
    const myBookButton = await page.locator('//a[text()="My Books"]');
    const addBookButton = await page.locator('//a[text()="Add Book"]');
    const logoutButton = await page.locator('//a[text()="Logout"]');


    const isEmailButtonVisible = await emailElement.isVisible();
    const isMyBookButtonVisible = await myBookButton.isVisible();
    const isAddBokButtonVisible = await addBookButton.isVisible();
    const isLogoutButtonVisible = await logoutButton.isVisible();

    expect(isEmailButtonVisible).toBe(true);
    expect(isMyBookButtonVisible).toBe(true);
    expect(isAddBokButtonVisible).toBe(true);
    expect(isLogoutButtonVisible).toBe(true);
});

//Login with valid credentials
test('/Login with valid credentials', async ({ page }) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    await expect(page.locator('a[href="/catalog"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/catalog');
});

//Login with Empty Input Fields
test('Login with Emtry Input Fields', async ({ page }) => {
    await page.goto('http://localhost:3000/login');

    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await expect(page.locator('a[href="/login"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/login');
});

//Login with Empty Email Input Field
test('Login with Empty Email Input Fields', async ({ page }) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await expect(page.locator('a[href="/login"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/login');
});

//Login with Empty Password Input Field
test('Login with Empty Password Input Fields', async ({ page }) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await expect(page.locator('a[href="/login"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/login');
});


