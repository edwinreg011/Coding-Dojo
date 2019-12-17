//get 1 to 255
function a(){
  for(var i = 0; i < 256; i++){
    arr.push(i);
  }
  return arr;
}

//get even 1000
function a(){
  var sum = 0;
  for(var i = 0; i < 1001; i++){
    if(i % 2 === 0){
      sum = sum + i;
    }
  }
  return sum;
}

//sum odd 5000
function a(){
  var sum = 0;
  for(var i = 0; i < arr.length; i++){
    if(i % 2 === 1){
      sum = sum + i;
    }
  }
  return sum;
}

//iterate an array 
function a(arr){
var sum = 0;
for(var i = 0; i < arr.length; i++){
  sum = sum + arr[i];
  }
  return sum; 
}

//find max
function a(arr){
  var max = 0;
  for(var i = 0; i < arr.length; i++){
    if(max < arr[i]){
      max = arr[i];
    }
  }
  return max;
}

//find avg 
fucntion a(arr){
  var sum = 0;
  for(var i = 0; i < arr.length; i++){
    sum = sum + arr[i];
  }
  var avg = sum / arr.length;
  return avg; 
}

//array odd
function a(){
  var arr = [];
  for(var i = 1; i < 51; i++){
    if( i % 2 === 1){
      arr.push(i);
    }
  }
  return arr;
}

//greater than Y
function a(arr, Y){
  var count = 0;
  for(var i = 0; i < arr.length; i++){
    if(arr[i] > Y){
      count++;
    }
  }
  return count;
}

//squares
function a(arr){
  for(var i = 0; i < arr.length; i++){
    arr[i] = arr[i] * arr[i];
  }
  return arr;
}

//negatives
function a(arr){
  for(var i = 0; i < arr.length; i++){
    if(arr[i] < 0){
      arr[i] = 0;
    }
  }
  return arr;
}

//max,min,avg
function a(arr){
  var max = 0;
  var min = 0;
  var sum = 0;
  for(var i = 0; i < arr.length; i++){
    if(max < arr[i]){
      max = arr[i];
    }
    if(min > arr[i]){
      min = arr[i];
    }
    sum = sum + arr[i];
  }
  var avg = sum / arr.length;
  var newarr = [max, min, avg];
  return newarr;
}

//swap values
function a(arr){
  var temp = arr[0];
  arr[0] = arr[arr.length - 1];
  arr[arr.length -1] = temp;
  return arr;
}

//number to string 
function a (arr){
  for(var i = 0; i < arr.length; i++){
    if(arr[i] < 0){
      arr[i] = 'Dojo';
    }
  }
  return arr;
}