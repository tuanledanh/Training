const menu = document.querySelector(".menu");
document.addEventListener("contextmenu", e=>{
    e.preventDefault(); //preventing default context menu of the browser
    let x = e.offsetX, y = e.offsetY; //get position of the mouse pointer 
    menu.style.left = `${x}px` ; //use the tilde symbol `, not '
    menu.style.top = `${y}px` ; //use the tilde symbol `, not '
    menu.style.visibility = 'visible';
});
document.addEventListener("click", function(){
    menu.style.visibility = 'hidden';
});