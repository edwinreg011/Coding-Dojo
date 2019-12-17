for(var x = 0; x < 5; x++){
$(document).ready(function(){
  var container = document.getElementById("container");
  var cat = document.createElement("h2");
  var que = document.createElement("h3");
  var ans = document.createElement("p");
  $.get("https://opentdb.com/api.php?amount=10", function (data){
    for(let key of data.results)
    {
      cat.innerHTML = key.category;
      que.innerHTML = key.question;
      ans.innerHTML = key.incorrect_answers + key.correct_answer;
      container.appendChild(cat);
      container.appendChild(que);
      container.appendChild(ans);
    }
    });
  });
} 