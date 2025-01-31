function solve() {
  let input = document.getElementById("text").value.toLowerCase();
  let namingConvention = document.getElementById("naming-convention").value;
  let resultSpan = document.getElementById("result");

  let splitted = input.split(' ');
  let resultString = '';

  if(namingConvention == "Camel Case")
    {
      resultString += splitted[0];
      for(let i = 1; i < splitted.length; i++){
        resultString += splitted[i][0].toUpperCase() + splitted[i].slice(1, splitted[i].length);
        resultSpan.textContent = resultString;
      }
    }
    else if(namingConvention == "Pascal Case")
    {
      for(let i = 0; i < splitted.length; i++){
        resultString += splitted[i][0].toUpperCase() + splitted[i].slice(1, splitted[i].length);
        resultSpan.textContent = resultString;
      }
    }
    else
    {
      resultSpan.textContent = "Error!";
    } 
  }