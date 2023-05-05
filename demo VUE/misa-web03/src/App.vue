<template>
  <div class="container">
    <TheNav></TheNav>
    <TheSideBar></TheSideBar>
    <TheContent></TheContent>
    <MISADialogNotice v-if="isShowNotice" :errors="errors" @onClose="isShowNotice = false"></MISADialogNotice>
  </div>
</template>

<script>
//Bước 1: import
import TheContent from "./layout/TheContent.vue";
import TheNav from "./layout/TheNav.vue";
import TheSideBar from "./layout/TheSideBar.vue";
import MISADialogNotice from "./components/MISADialogNotice.vue";
export default {
  name: "App",
  components: {
    TheContent,
    TheNav,
    TheSideBar,
    MISADialogNotice,
  },
  created() {
    this.$memitter.on("showNotice", this.showNotice);
  },
  beforeUnmount() {
    this.$memitter.off("showNotice");
  },
  methods: {
    showNotice(errors) {
      this.isShowNotice = true;
      this.errors = errors;
    },
  },
  data() {
    return {
      isShowNotice: false,
      errors: [],
    };
  },
};
</script>
<style>
@import url(./css/main.css);
</style>
