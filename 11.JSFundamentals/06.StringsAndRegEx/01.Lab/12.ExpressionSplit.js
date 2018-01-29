function expressionSplit(text) {
    let elements = text
    .split(/[\s.();,]+/);
  console.log(elements.join("\n"));

}

expressionSplit('let sum = 4 * 4,b = "wow";');