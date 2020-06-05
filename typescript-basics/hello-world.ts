// Declare types in TypeScript
var a: number;
var b: boolean;
var c: string;
var foo: undefined;

a = 10;
b = true;
c = 'Hello World';

var testArray: number[];
testArray = [];
testArray = [1,2,3];
testArray.push(4);
testArray.splice(1);
console.log(testArray);

// tuple em TypeScript
var testArrayTuple: [number, boolean] =  [1, true];

testArrayTuple = [5,false];
testArrayTuple = [10,true], [5, true];

