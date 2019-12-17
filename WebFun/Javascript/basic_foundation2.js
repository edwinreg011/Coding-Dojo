//biggie size
function biggiesize(arr){
  for(var i = 0; i < arr.length; i++){
    if( arr[i] > 0){
      arr[i] = 'big';
    }
  }
  return arr;
}

//print low, return high // moving backwards
function printlowreturnhigh(arr){
  var min = arr[arr.length - 1];
  var max = arr[arr.length - 1];
  for(var i = arr.length - 1; i >= 0; i--){
    if(min > arr[i]){
      min = arr[i];
    }
    if(max < arr[i]){
      max = arr[i];
    }
  }
  console.log(min);
  return max;
}

//print one, return another
funciton PrintOneReturnOne(arr){
  console.log(arr[arr.length - 2]);
  for(var i = 0; i < arr.length; i++){
    if(arr[i] % 2 === 1){
      return arr[i];
    }
  }
}

//double vision
var original = [1,2,3];
function DoubleVision(){
  var output = [];
  for(var i = 0; i < arr.length; i++){
    output.push( arr[i] * 2);
  }
  return output; 
}

//count positives
var number = [-1,1,1,1];
function countpositives(arr){
  var count = 0;
  for(var i = 0; i < arr.length; i++){
  if(arr[i] > 0){
    count++;
    }
  }
  arr[arr.length - 1] = count;
}

//evens and odds
function evensOdds(arr){
  var odds = 0;
  var evens = 0;
  for( var i = 0; i < arr.length; i++){
    if( arr[i] % 2 === 0){
      odds = 0;
      evens ++
      if(evens > 2){
        console.log("Even more so")
      }
    }
    else{
      evens = 0;
      odds ++;
      if(odds > 2){
        console.log("That's odd!");
      }
    }
  }
}

//increment the seconds 
function increment(arr){
  for(var i = 0; i < arr.length; i++){
    if(i % 2 === 1){
      arr[i] = arr[i] + 1;
    }
    console.log(arr[i]);
  }
  return arr;
}

//previous lengths


//add seven
function addSeven(arr){
  var newarr = [];
  for(var i = 0; i < arr.length; i++){
    newarr.push( arr[i] = arr[i] + 7);
  }
  return newarr;
}

//reverse array


//outlook: negative
function negativeArray(arr){
  var newarr = [];
  for(var i = 0; i < arr.length; i++){
    if(arr[i] > 0){
      arr[i] = arr[i] - arr[i] * 2;
      newarr.push(arr[i]);
    }
    else{
      arrnew.push(arr[i]);
    }
  }
  return newarr;
}

//always hungry


//swap toward the center


//scale the array 
function scaleArray(arr, num){
  for(var i = 0; i < arr.length; i++){
    arr[i] = arr[i] * num;
  }
  return arr;
}

