module("MovingGameObject.init");
test("Testing constructor", function () {
    var position = { x: 20, y: 30 };
    var size = 10;
    var fcolor = "#000000";
    var scolor = "#ffffff";
    var speed = 10;
    var direction = 1;

    var movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    equal(position.x, movingObj.position.x, "Checking position x");
    equal(position.y, movingObj.position.y, "Checking position y");
    equal(size, movingObj.size, "Checking size");
    equal(fcolor, movingObj.fcolor, "Checking fill color");
    equal(scolor, movingObj.scolor, "Checking stroke color");
    equal(speed, movingObj.speed, "Checking speed");
    equal(direction, movingObj.direction, "Checking direction");
});

module("MovingGameObject.move")
test("Move left", function () {
    var position = { x: 20, y: 30 };
    var size = 10;
    var fcolor = "#000000";
    var scolor = "#ffffff";
    var speed = 10;
    var direction = 0;

    var movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    var expectedPosition = { x: position.x - speed, y: position.y };
    movingObj.move();

    equal(expectedPosition.x, movingObj.position.x, "Position X after move");
    equal(expectedPosition.y, movingObj.position.y, "Position y after move");

    expectedPosition.x = 0 - speed;
    movingObj.position.x = 0;
    movingObj.move();
    equal(expectedPosition.x, movingObj.position.x, "Position X after move from zero");
    equal(expectedPosition.y, movingObj.position.y, "Position y after move from zero");
});

test("Move right", function () {
    var position = { x: 50, y: 40 };
    var size = 10;
    var fcolor = "#000000";
    var scolor = "#ffffff";
    var speed = 2;
    var direction = 2;

    var movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    var expectedPosition = { x: position.x + speed, y: position.y };
    movingObj.move();

    equal(expectedPosition.x, movingObj.position.x, "Position X after move");
    equal(expectedPosition.y, movingObj.position.y, "Position y after move");

    expectedPosition.x = 0 + speed;
    movingObj.position.x = 0;
    movingObj.move();
    equal(expectedPosition.x, movingObj.position.x, "Position X after move from zero");
    equal(expectedPosition.y, movingObj.position.y, "Position y after move from zero");
});

test("Move up", function () {
    var position = { x: 20, y: 30 };
    var size = 10;
    var fcolor = "#000000";
    var scolor = "#ffffff";
    var speed = 5;
    var direction = 1;

    var movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    var expectedPosition = { x: position.x, y: position.y - speed };
    movingObj.move();

    equal(expectedPosition.x, movingObj.position.x, "Position X after move");
    equal(expectedPosition.y, movingObj.position.y, "Position y after move");

    expectedPosition.y = 0 - speed;
    movingObj.position.y = 0;
    movingObj.move();
    equal(expectedPosition.x, movingObj.position.x, "Position X after move from zero");
    equal(expectedPosition.y, movingObj.position.y, "Position y after move from zero");
});

test("Move down", function () {
    var position = { x: 15, y: 15 };
    var size = 10;
    var fcolor = "#000000";
    var scolor = "#ffffff";
    var speed = 1;
    var direction = 3;

    var movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    var expectedPosition = { x: position.x, y: position.y + speed };
    movingObj.move();

    equal(expectedPosition.x, movingObj.position.x, "Position X after move");
    equal(expectedPosition.y, movingObj.position.y, "Position y after move");

    expectedPosition.y = 0 + speed;
    movingObj.position.y = 0;
    movingObj.move();
    equal(expectedPosition.x, movingObj.position.x, "Position X after move from zero");
    equal(expectedPosition.y, movingObj.position.y, "Position y after move from zero");
});

module("MovingGameObject.changeDirection");
test("Change direction from left", function () {
    var position = { x: 15, y: 15 };
    var size = 10;
    var fcolor = "#000000";
    var scolor = "#ffffff";
    var speed = 1;
    var direction = 0;

    var movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObj.changeDirection(-1);
    equal(0, movingObj.direction,"to invalid (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(0);
    equal(0, movingObj.direction, "to same (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(1);
    equal(1, movingObj.direction, "to up (allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(2);
    equal(0, movingObj.direction, "to right (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(3);
    equal(3, movingObj.direction, "to down (allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(4);
    equal(0, movingObj.direction, "to invalid (not allowed)");
});

test("Change direction from right", function () {
    var position = { x: 15, y: 15 };
    var size = 10;
    var fcolor = "#000000";
    var scolor = "#ffffff";
    var speed = 1;
    var direction = 2;

    var movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObj.changeDirection(-1);
    equal(2, movingObj.direction, "to invalid (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(0);
    equal(2, movingObj.direction, "to left (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(1);
    equal(1, movingObj.direction, "to up (allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(2);
    equal(2, movingObj.direction, "to same (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(3);
    equal(3, movingObj.direction, "to down (allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(4);
    equal(2, movingObj.direction, "to invalid (not allowed)");
});

test("Change direction from up", function () {
    var position = { x: 50, y: 55 };
    var size = 15;
    var fcolor = "#000000";
    var scolor = "#ffffff";
    var speed = 5;
    var direction = 1;

    var movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObj.changeDirection(-1);
    equal(1, movingObj.direction, "to invalid (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(0);
    equal(0, movingObj.direction, "to left (allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(1);
    equal(1, movingObj.direction, "to same (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(2);
    equal(2, movingObj.direction, "to right (allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(3);
    equal(1, movingObj.direction, "to down (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(4);
    equal(1, movingObj.direction, "to invalid (not allowed)");
});

test("Change direction from down", function () {
    var position = { x: 50, y: 55 };
    var size = 5;
    var fcolor = "#000000";
    var scolor = "#ffffff";
    var speed = 15;
    var direction = 3;

    var movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    movingObj.changeDirection(-1);
    equal(3, movingObj.direction, "to invalid (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(0);
    equal(0, movingObj.direction, "to left (allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(1);
    equal(3, movingObj.direction, "to up (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(2);
    equal(2, movingObj.direction, "to right (allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(3);
    equal(3, movingObj.direction, "to same (not allowed)");

    movingObj.direction = direction;
    movingObj.changeDirection(4);
    equal(3, movingObj.direction, "to invalid (not allowed)");
});