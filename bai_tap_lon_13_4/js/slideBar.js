/**
 * changes the background color of sideBar item and 
 * color of the text content of a sideBar item when click
 * @param slideBarItems get all the sideBar items
 * @param slideBarItemName the text content of sideBar item
 * Author: LDTUAN (18/04/2023)
 */
function changeColorSideBarItem() {
  const slideBarItems = document.querySelectorAll(".slide-bar__item");
  slideBarItems.forEach(function (slideBarItem) {
    slideBarItem.onclick = function () {
      slideBarItems.forEach(function (otherSlideBarItem) {
        const slideBarItemName = otherSlideBarItem.querySelector(
          ".slide-bar__item-name"
        );
        otherSlideBarItem.classList.remove("slide-bar__item--active");
        slideBarItemName.style.color = "#869AB8";
      });
      const slideBarItemName = slideBarItem.querySelector(
        ".slide-bar__item-name"
      );
      slideBarItem.classList.add("slide-bar__item--active");
      slideBarItemName.style.color = "#FFFFFF";
    };
  });
}

