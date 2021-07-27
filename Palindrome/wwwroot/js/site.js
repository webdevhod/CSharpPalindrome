// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let resetButton = document.getElementById("resetButton");
let runButton = document.getElementById("runButton");

runButton.addEventListener("click", runCode);
resetButton.addEventListener("click", resetText);

let resultDisplay = document.getElementById("result");
let resultText = document.getElementById("result__text");

function runCode() {
  let text = document.getElementById("inputText").value;

  let isPalindrome = checkPalindrome(text);

  displayText(text, isPalindrome);
}

function checkPalindrome(text) {
  let startIndex = 0;
  let endIndex = text.length - 1;

  while (startIndex < endIndex) {
    if(!checkValidChar(text[startIndex])) {
      startIndex += 1;
    } else if (!checkValidChar(text[endIndex])) {
      endIndex -= 1;
    } else if(text[startIndex].toLowerCase() === text[endIndex].toLowerCase()) {
      startIndex += 1;
      endIndex -= 1;
    } else {
      return false;
    }
  }
  return true;
}


function checkValidChar(c) {
  return (/[a-zA-z0-9]/).test(c);
}


function displayText(text, isPalindrome) {
  resetText();
  resultText.innerHTML = `"${text}" <span class="fw-bold">is${isPalindrome ? "" : " not"}</span> a palindrome.`;
  resultDisplay.classList.add(`${isPalindrome ? "alert-primary" : "alert-danger"}`);
  resultDisplay.classList.remove("invisible");
}

function resetText() {
  resultText.innerHTML = "";
  resultDisplay.classList.add("invisible");
  resultDisplay.classList.remove("alert-primary", "alert-danger");
}