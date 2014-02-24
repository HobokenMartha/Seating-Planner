function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("Text", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("Text");
    ev.target.appendChild(document.getElementById(data));
}


// Reports the position of an element in the DOM
// Based upon the function defined here http://www.kirupa.com/html5/get_element_position_using_javascript.htm
function getPosition(element) {
    var x = 0;
    var y = 0;

    while (element) {
        x += (element.offsetLeft - element.scrollLeft + element.clientLeft);
        y += (element.offsetTop - element.scrollTop + element.clientTop);

        element = element.offsetParent;
    }

    return [x, y];
}