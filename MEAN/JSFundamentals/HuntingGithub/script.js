$(document).ready(function(){
  $("button").click(function(){
    var container = document.getElementById('container');
    var elem = document.createElement("h1");
    $.get("https://api.github.com/users/edwinreg011", function(data){
      elem.innerHTML = data.login + " is the Github user!";
      container.appendChild(elem);
    });
  });
})