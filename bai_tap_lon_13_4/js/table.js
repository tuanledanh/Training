/**
 * Tick all records when user click the header checkbox
 * @param headerCheckbox get input element with type = checkbox of header in the table
 * @param dataCheckboxes get all input elements with type = checkbox of data in the table
 * @param dataRows get all row data of the table
 * Author: LDTUAN (18/04/2023)
 */
const headerCheckbox = document.querySelector(
  '.head__checkbox input[type="checkbox"]'
);
const dataCheckboxes = document.querySelectorAll(
  '.data__checkbox input[type="checkbox"]'
);
const dataRows = document.querySelectorAll(".table__data");
function checkboxHeaderClick() {
  headerCheckbox.onclick = function () {
    if (headerCheckbox.checked) {
      dataRows.forEach(function (row) {
        row.classList.add("row__selected");
      });
      dataCheckboxes.forEach(function (checkbox) {
        checkbox.checked = true;
      });
    } else {
      dataRows.forEach(function (row) {
        row.classList.remove("row__selected");
      });
      dataCheckboxes.forEach(function (checkbox) {
        checkbox.checked = false;
      });
    }
  };
}


/**
 * Change the background color of row when data checkbox be checked, and
 * uncheck header checkbox if a data checkbox is not be checked
 * @param dataCheckboxes get all input elements with type = checkbox of data in the table
 * @param dataRows get all row data of the table
 * Author: LDTUAN (18/04/2023)
 */
function changeRowColor() {
  dataCheckboxes.forEach(function (checkbox) {
    checkbox.onchange = function () {
      const rowIndex = Array.from(dataRows).indexOf(
        checkbox.closest(".table__data")
      );
      const selectedRows = Array.from(dataRows).slice(rowIndex, rowIndex + 4);
      selectedRows.forEach(function (row) {
        if (checkbox.checked) {
          row.classList.add("row__selected");
        } else {
          row.classList.remove("row__selected");
          headerCheckbox.checked = false;
        }
      });
    };
  });
}

/**
 * Set checked for the checkbox when click a row, and avoid to double click
 * when user click checkbox
 * @param tableBodyRows get all the block table body
 * @param checkBox is the input element type = checkbox of the row
 * Author: LDTUAN (18/04/2023) 
 */
function checkRow() {
  const tableBodyRows = document.querySelectorAll(".table__body");
  tableBodyRows.forEach(function (bodyRow) {
    bodyRow.onclick = function () {
      const checkBox = bodyRow.querySelector(
        '.data__checkbox input[type="checkbox"]'
      );
      if (checkBox === event.target) {
        // if user click checkBox, do nothing, because checkBox will be double click
        return;
      }
      if (checkBox.checked) {
        checkBox.checked = false;
        checkBox.onchange();
      } else {
        checkBox.checked = true;
        checkBox.onchange();
      }
    };
  });
}

