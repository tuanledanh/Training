<template>
  <div class="dialog" id="dialog-notice">
    <div class="dialog-wrapper">
      <div class="dialog__header">
        <div class="header__text">Dữ liệu không hợp lệ</div>
        <div class="header__icon" @click="btnCloseOnClick">
          <div class="icon-exit">
            <div class="icon--exit"></div>
          </div>
        </div>
      </div>
      <div class="dialog__content">
        <div class="dialog-content__icon icon--warning"></div>
        <ul class="dialog-content__message">
          <li v-for="(item, index) in errors" :key="index">{{ item }}</li>
        </ul>
      </div>
      <div class="dialog__footer">
        <button class="button button--primary">Đồng ý</button>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "MISADialogNotice",
  props: ["errors"],
  methods: {
    btnCloseOnClick(){
      this.$emit("onClose");
    }
  },
  data() {
    return {};
  },
};
</script>
