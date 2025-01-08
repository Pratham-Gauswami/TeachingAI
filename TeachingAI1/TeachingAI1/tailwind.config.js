/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Views/**/*.cshtml', // Include Razor views
    './wwwroot/**/*.html', // Include any static HTML
    './Pages/**/*.cshtml', // Include Razor Pages (if using)
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}

