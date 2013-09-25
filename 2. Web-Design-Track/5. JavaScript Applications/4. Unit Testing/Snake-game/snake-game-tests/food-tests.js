test("Food constructor", function () {
    var position = { x: 15, y: 25 };
    var size = 5;

    var foodObj = new snakeGame.Food(position, size);

    equal(foodObj.position.x, position.x, "Check position X");
    equal(foodObj.position.y, position.y, "Check position Y");
    equal(foodObj.size, size, "Check size");
})
