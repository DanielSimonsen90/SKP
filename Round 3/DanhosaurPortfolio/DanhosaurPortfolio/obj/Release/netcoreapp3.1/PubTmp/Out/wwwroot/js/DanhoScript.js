/**Sets navigationItemSelected to the navigation item that represents the page user is viewing */
function onStartUp() {
    //Get the page user is viewing
    var currentPage = document.location.href;

    //Remove all navigationItemSelected from the navigation bar items (what indicates user is viewing this page)
    $("header a").each(() => $(this).removeClass("navigationItemSelected"));

    //Find the item that needs to add navigationItemSelected and add the item
    $("header").find("a").each((_, element) => {
        if (element.href == currentPage)
            element.setAttribute("class", `${element.classList} navigationItemSelected`);
    });
}

/**Copies item to clipboard, and displays itemString in alert message as "Du har kopieret ${itemString}"
 * @param {string} item item that should be copied
 * @param {string} itemString item description; displays in alert message*/
function CopyToClipboard(item, itemString) {
    //Create a new input element with type textarea
    var input = document.createElement('textarea');

    //Give the website body the new input variable
    document.body.appendChild(input);

    //Input's value is the item/string we're copying
    input.value = item;

    //Select the value (sort of like crtl + a)
    input.select();

    //Run the copy command
    document.execCommand("copy");

    //yeet the input
    document.body.removeChild(input);

    //Let user know they copied the item, though using itemString, as input and output might be different
    alert(`Du har kopieret ${itemString}`);
}

/**@param {boolean} hovering*/
function ImageHover(hovering) {
    //In the document, find an element with the class "logo"
    //Take the first result (there's only 1 in the navigation header) 
    //Change its source depending whether the hovering paramter is true or false
    document.getElementsByClassName("logo").item(0).src = `${document.location.origin}/Images${(hovering ? `/Logo Hover.png` : `/Logo.png`)}`;
}