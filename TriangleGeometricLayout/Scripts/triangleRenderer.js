

// function to draw but not fill the triangle needed because isPointInPath only tests the last defined path
function define(shape) {
    var points = shape.points;
    ctx.beginPath();
    ctx.moveTo(points[0].x, points[0].y);
    for (var i = 1; i < points.length; i++) {
        ctx.lineTo(points[i].x, points[i].y);
    }
    ctx.closePath();
}

//generates the x,y for the triangle array
function generateTriangles() {
    function scaled(i) {
        return i * scale;
    }

    function scaledPlusOffset(i) {
        return (i * scale) + scale;
    }

    for (var x = 0; x < 6; x++) {
        for (var y = 0; y < 6; y++) {

            triangles.push({
                points: [
                    { x: scaled(x), y: scaled(y) },
                    { x: scaled(x), y: scaledPlusOffset(y) },
                    { x: scaledPlusOffset(x), y: scaledPlusOffset(y) }
                ],
                row: rows[y],
                column: (1 + (x * 2)),
                message: rows[y] + (1 + (x * 2))
            });
            triangles.push({
                points: [
                    { x: scaled(x), y: scaled(y) },
                    { x: scaledPlusOffset(x), y: scaled(y) },
                    { x: scaledPlusOffset(x), y: scaledPlusOffset(y) }
                ],
                row: rows[y],
                column: (2 + (x * 2)),
                message: rows[y] + (2 + (x * 2))
            });
        }
    }
}

//draws the shape on the canvas
function draw(shape) {
    //gets the center of the shape
    function getCenter(shape) {
        return {
            x: (shape.points[0].x + shape.points[1].x + shape.points[2].x) / 3,
            y: (shape.points[0].y + shape.points[1].y + shape.points[2].y) / 3
        };
    }

    define(shape);
    // Easier to see the text.
    ctx.fillStyle = "#5B9BD5";
    ctx.strokeStyle = "#ffffff";
    ctx.stroke();
    ctx.fill();
    ctx.fillStyle = 'white';
    // Draw text `Ball # i` centered at position (x, y),
    // with the width of the text equal to ball's size * 2.
    var center = getCenter(shape);
    ctx.fillText(shape.message, center.x, center.y);
}


// canvas variables
var canvas;
var ctx;
var viewportOffset;

// these are relative to the viewport, i.e. the window
var offsetY;
var offsetX;

//row names 
var rows = ['A', 'B', 'C', 'D', 'E', 'F'];

// set styles
var scale = 50;

// save the triangle objects
var triangles = [];
var rowElement;
var columnElement;
var p1IdElement;
var p2IdElement;
var p3IdElement;




function init(rowId, columnId, p1Id, p2Id, p3Id) {
    canvas = document.getElementById("canvas");
    ctx = canvas.getContext("2d");
    ctx.textAlign = 'center'; // Set text align to center.
    ctx.textBaseline = 'middle'; // Set text vertical align to middle.
    viewportOffset = canvas.getBoundingClientRect();
    offsetY = viewportOffset.top;
    offsetX = viewportOffset.left;

    //document.getElementById("mytext").value = "My value";
    rowElement = document.getElementById(rowId);
    columnElement = document.getElementById(columnId);
    p1IdElement = document.getElementById(p1Id);
    p2IdElement = document.getElementById(p2Id);
    p3IdElement = document.getElementById(p3Id);

    

    canvas.addEventListener("mousedown", function (e) {
        e.preventDefault();

        // get the mouse position
        var mouseX = parseInt(e.clientX - offsetX);
        var mouseY = parseInt(e.clientY - offsetY);

        // iterate each shape in the shapes array
        for (var i = 0; i < triangles.length; i++) {
            var triangle = triangles[i];
            // define the current shape
            define(triangle);
            // test if the mouse is in the current shape
            if (ctx.isPointInPath(mouseX, mouseY)) {
                rowElement.value = triangle.row;
                columnElement.value = triangle.column;
                p1IdElement.value = JSON.stringify(triangle.points[0]);
                p2IdElement.value = JSON.stringify(triangle.points[1]);
                p3IdElement.value = JSON.stringify(triangle.points[2]);
            }
        }
    });
}

//draws all of the triangles
function drawTriangles(rowId, columnId, p1Id, p2Id, p3Id ) {
    init(rowId, columnId, p1Id, p2Id, p3Id);

    generateTriangles();

    for (var i = 0; i < triangles.length; i++) {
        draw(triangles[i]);
    }
}

