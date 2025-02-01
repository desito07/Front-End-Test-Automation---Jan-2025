const { test, expect } = require('@playwright/test');
 // Define the test suite
 test('Page has Playwright in title', async ({ page }) => {
  await page.goto('https://playwright.dev/');
  const title = await page.title();
  // Define the test cases
  expect(title).toBe('Fast and reliable end-to-end testing for modern web apps | Playwright');
 });