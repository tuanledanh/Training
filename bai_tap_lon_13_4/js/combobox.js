window.onload = function () {
  initCombobox();
};

function initCombobox() {
  // lấy ra tất cả mcombobox
  const mcomboboxs = document.querySelectorAll(".mcombobox");
  // duyệt và gán sự kiện cho các mcombobox
  for (const mcombobox of mcomboboxs) {
    buildComboboxData(mcombobox);
    initEvents(mcombobox);
    // gán sự kiện cho input thực hiện lọc dữ liệu
    const mcomboboxInput = mcombobox.querySelector(".mcombobox__input");
    mcomboboxInput.oninput = filterDataMCombobox;
  }
}

function filterDataMCombobox() {
  // lấy ra text của input
  const text = this.value.toLowerCase();
  // lọc dữ liệu dựa trên text của input
  // xác định text của đối tượng để lọc
  const mcombobox = this.parentElement;
  const propText = mcombobox.getAttribute("propText");
  const data = mcombobox.data;
  const dataFilter = data.filter((item) =>
    item[propText].toLowerCase().includes(text)
  );
  const comboboxDataElement = mcombobox.querySelector(".mcombobox__data");
  // làm sạch data cũ trước khi filter
  comboboxDataElement.innerHTML = "";
  // build lại data mới sau khi filter
  if (dataFilter && dataFilter.length > 0) {
    const propValue = mcombobox.getAttribute("propValue");
    for (const item of dataFilter) {
      const textItem = item[propText];
      const valueItem = item[propValue];
      const itemElement = document.createElement("a");
      itemElement.classList.add("mcombobox-item");
      itemElement.setAttribute("value", valueItem);
      itemElement.innerHTML = textItem;
      // tạo sự kiện cho itemElement
      itemElement.onclick = comboboxDataItemOnSelect;
      // append itemElement vào trong element combobox data
      comboboxDataElement.append(itemElement);
    }
  }
  // hiển thị combobox data khi filter
  comboboxDataElement.classList.remove("mcombobox__data--hide");
}

async function buildComboboxData(mcombobox) {
  // xác định api sẽ lấy dữ liệu:
  const api = mcombobox.getAttribute("api");
  const comboboxButton = mcombobox.querySelector(".mcombobox__button");
  // set disabled để khi load data từ api xong thì mới cho xài button xổ xuống
  comboboxButton.setAttribute("disabled", true);
  // gọi api lấy dữ liệu về
  await fetch(api)
    .then((res) => res.json())
    .then((data) => {
      // lưu data cho combobox
      mcombobox.data = data;
      // xác định được thông tin nào sẽ là text và thông tin nào là value trên từng item
      const propText = mcombobox.getAttribute("propText");
      const propValue = mcombobox.getAttribute("propValue");
      const comboboxDataElement = mcombobox.querySelector(".mcombobox__data");
      // duyệt từng đối tượng trong mảng dữ liệu trả về và build các item tương ứng
      if (data && data.length > 0) {
        console.log(data);
        for (const item of data) {
          const text = item[propText];
          const value = item[propValue];
          const itemElement = document.createElement("a");
          itemElement.classList.add("mcombobox-item");
          itemElement.setAttribute("value", value);
          itemElement.innerHTML = text;
          // tạo sự kiện cho itemElement
          itemElement.onclick = comboboxDataItemOnSelect;
          // append itemElement vào trong element combobox data
          comboboxDataElement.append(itemElement);
        }
        comboboxButton.removeAttribute("disabled");
      }
    });
}

function initEvents(mcombobox) {
  mcombobox
    .querySelector(".mcombobox__button")
    .addEventListener("click", comboboxButtonOnClick);
  let comboboxDataItems = mcombobox.querySelectorAll(".mcombobox-item");
  for (const item of comboboxDataItems) {
    item.onclick = comboboxDataItemOnSelect;
  }
}
/**
 * Ẩn hiện combobox data
 * Author: LDTUAN (20/04/2023)
 */
function comboboxButtonOnClick() {
  const mcomboboxData = this.nextElementSibling;
  mcomboboxData.classList.toggle("mcombobox__data--hide");
}

function comboboxDataItemOnSelect() {
  console.log(this);
  // xác định item đang chọn

  // lấy ra text và value của item đã chọn
  const text = this.textContent;
  const value = this.getAttribute("value");
  // hiển thị text của item lên input của combobox
  let mcombobox = this.parentElement.parentElement;
  mcombobox.firstElementChild.value = text;
  // lưu giá trị đã chọn cho combobox, đặt tên value là gì cũng đc: mvalue, abcvalue
  mcombobox.mvalue = value;
  // ẩn combobox data
  this.parentElement.classList.add("mcombobox__data--hide");
}

// yêu cầu: thêm icon quay tròn lúc ng dùng đang nhập
//vào ô input, thêm thời gian delay
//focus vào option đầu tiên khi search

//tạo mỗi 1 khối <mcombobox api = "abc" proptext ="" propvalue =""></mcombobox>
//mà nó gen ra cả khối như dưới
/* <div class="mcombobox__data">
<a class="mcombobox-item" value="1">Hà Nội</a>
<a class="mcombobox-item --selected"  value="2">Hải Phòng</a>
<a class="mcombobox-item" value="3">Quảng Ninh</a>
</div> */
