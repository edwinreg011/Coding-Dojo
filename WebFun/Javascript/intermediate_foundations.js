//sigma
function simga(num){
  var sum = 0;
  for(var i = 0; i <= num; i++){
    sum = sum + i;
  }
  return sum;
}

//factorial
function factorial(num){
  var prod = 1;
  for(var i = 1; i <= num; i++){
    prod = prod * i;
  }
  return prod;
}

//fibonacci
function fib(num){
  var arr = [0,1]; 
  for(var i = 2; i < num; i++){
    arr[i] = arr[i]-1 + arr[i]-2;
  }
  return arr[n];
}


//second to last
function secLast(arr){
  if(arr.length < 2){
    return "null";
  }
  else{
    return arr[arr.length - 2];
  }
}

//nth to last
functon nLast(arr, n){
  if(arr.length + 1 < n){
    return "null";
  }
  else{
    return arr[arr.length - n];
  }
}

//second largest


//double trouble
function dubTrouble(arr){
  var newarr = [];
  for(var i = 0; i < arr.length; i++){
    newarr.push(arr[i]);
    newarr.push(arr[i]);
  }
  return newarr; 
}