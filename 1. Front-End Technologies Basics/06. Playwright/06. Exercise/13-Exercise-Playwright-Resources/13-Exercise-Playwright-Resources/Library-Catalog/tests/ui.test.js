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
test('Login with valid credentials', async ({ page }) => {
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

//Register the Form with Valid Values
test('Register the Form with Valid Values', async ({ page }) => {
    await page.goto('http://localhost:3000/register');

    await page.fill('input[name="email"]', 'demi@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.fill('input[name="confirm-pass"]', '123456');
    await page.click('input[type="submit"]');

    await expect(page.locator('a[href="/catalog"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/catalog');
});

//Register the Form with Empty Values
test('Register the Form with Empty Values', async ({ page }) => {
    await page.goto('http://localhost:3000/register');

    await page.click('input[type="submit"]');
    
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await expect(page.locator('a[href="/register"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/register');
});

//Register the Form with Empty Email
test('Register the Form with Empty Email', async ({ page }) => {
    await page.goto('http://localhost:3000/register');

    await page.fill('input[name="password"]', '123456');
    await page.fill('input[name="confirm-pass"]', '123456');
    await page.click('input[type="submit"]');
    
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await expect(page.locator('a[href="/register"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/register');
});

//Register the Form with Empty Password
test('Register the Form with Empty Password', async ({ page }) => {
    await page.goto('http://localhost:3000/register');

    await page.fill('input[name="email"]', 'papi@abv.bg');
    await page.fill('input[name="confirm-pass"]', '123456');
    await page.click('input[type="submit"]');
    
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await expect(page.locator('a[href="/register"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/register');
});

//Register the Form with Empty Confirm Password
test('Register the Form with Empty Confirm Password', async ({ page }) => {
    await page.goto('http://localhost:3000/register');

    await page.fill('input[name="email"]', 'nani@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await expect(page.locator('a[href="/register"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/register');
});

//Register the Form with Different Passwords
test('Register the Form with Different Passwords', async ({ page }) => {
    await page.goto('http://localhost:3000/register');

    await page.fill('input[name="email"]', 'pepi@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.fill('input[name="confirm-pass"]', '987654');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("Passwords don't match!");
        await dialog.accept();
    });

    await expect(page.locator('a[href="/register"]')).toBeVisible();
    expect(page.url()).toBe('http://localhost:3000/register');
});

//Add Book Page - Submit the Form with Correct Data
test('Add Book Page - Submit the Form with Correct Data', async({page}) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
        ]);

    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');

    await page.fill('#title', 'Test Book');
    await page.fill('#description', 'test test test');
    await page.fill('#image', 'https://example.com/book-image.jpg');
    await page.selectOption('#type', 'Fiction');

    page.click('#create-form input[type="submit"]');

    await page.waitForURL('http://localhost:3000/catalog');
    expect(page.url()).toBe('http://localhost:3000/catalog');
    });

//Add Book Page - Submit the Form with Empty Title Field
test('Add Book Page - Submit the Form with Empty Title Field', async({page}) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
        ]);

    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');

    await page.fill('#description', 'test test test');
    await page.fill('#image', 'https://example.com/book-image.jpg');
    await page.selectOption('#type', 'Romance');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await page.locator('a[href="/create"]');
    expect(page.url()).toBe('http://localhost:3000/create');
    });

//Add Book Page - Submit the Form with Empty Description Field
test('Add Book Page - Submit the Form with Empty Description Field', async({page}) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
        ]);

    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');

    await page.fill('#title', 'Test Book');
    await page.fill('#image', 'https://example.com/book-image.jpg');
    await page.selectOption('#type', 'Romance');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await page.locator('a[href="/create"]');
    expect(page.url()).toBe('http://localhost:3000/create');
    });

//Add Book Page - Submit the Form with Empty Image URL Field
test('Add Book Page - Submit the Form with Empty Image URL Field', async({page}) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
        ]);

    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');

    await page.fill('#title', 'Test Book');
    await page.fill('#description', 'test test test');
    await page.selectOption('#type', 'Romance');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain("All fields are required!");
        await dialog.accept();
    });

    await page.locator('a[href="/create"]');
    expect(page.url()).toBe('http://localhost:3000/create');
    });

//Verify That All Books Are Displayed
test('Verify That All Books Are Displayed', async ({ page }) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
        ]);
    await page.waitForSelector('.dashboard');
    const bookElements = await page.locator('.other-books-list li').count();

    expect(bookElements).toBeGreaterThan(0);
});

//Verify That No Books Are Displayed
test('Verify That No Books Are Displayed', async ({ page }) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
        ]);
    await page.waitForSelector('.dashboard');

    const noBooksMessage = await page.textContent('.no-books');
    expect(noBooksMessage).toBe('No books in the database!');
});

//Verify That Logged-In User Sees Details Button and Button Works Correctly
test('Verify That Logged-In User Sees Details Button and Button Works Correctly', async({page}) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'john@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
        ]);

    await page.click('a[href="/catalog"]');
    await page.waitForSelector('.otherBooks');
    await page.click('.otherBooks a.button');
    await page.waitForSelector('.book-information');

    const detailsPageTitle = await page.textContent('.book-information h3');
    expect(detailsPageTitle).toBe('To Kill a Mockingbird');
});

//Verify That All Info Is Displayed Correctly
test('Verify That All Info Is Displayed Correctly', async ({ page }) => {
    await page.goto('http://localhost:3000/catalog');
    await page.click('a[href="/catalog"]');
    await page.waitForSelector('.otherBooks');
    const detailsButton = await page.locator('a[href="/catalog"]');
    const isDetailsuttonVisible = await detailsButton.isVisible();
    expect(isDetailsuttonVisible).toBe(true);
});








































//Verify That the "Logout" Button Is Visible
test('Verify That the "Logout" Button Is Visible', async({page}) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');
    
    const logoutLink = await page.locator('a[href="javascript:void(0)"]');
    await logoutLink.click();
});

//Verify That the "Logout" Button Redirects Correctly
test('Verify That the "Logout" Button Redirects Correctly', async ({ page }) => {
    await page.goto('http://localhost:3000/login');

    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    const logoutLink = await page.locator('a[href="javascript:void(0)"]');
    await logoutLink.click();

    const redirectedURL = page.url();
    expect(redirectedURL).toBe('http://localhost:3000/catalog');
});

