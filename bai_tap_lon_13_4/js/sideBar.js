/**
 * changes the background color of sideBar item and 
 * color of the text content of a sideBar item when click
 * @param sideBarItems get all the sideBar items
 * @param sideBarItemName the text content of sideBar item
 * Author: LDTUAN (18/04/2023)
 */
function changeColorSideBarItem() {
  const sideBarItems = document.querySelectorAll(".side-bar__item");
  sideBarItems.forEach(function (sideBarItem) {
    sideBarItem.onclick = function () {
      sideBarItems.forEach(function (othersideBarItem) {
        const sideBarItemName = othersideBarItem.querySelector(
          ".side-bar__item-name"
        );
        othersideBarItem.classList.remove("side-bar__item--active");
        sideBarItemName.style.color = "#869AB8";
      });
      const sideBarItemName = sideBarItem.querySelector(
        ".side-bar__item-name"
      );
      sideBarItem.classList.add("side-bar__item--active");
      sideBarItemName.style.color = "#FFFFFF";
    };
  });
}

