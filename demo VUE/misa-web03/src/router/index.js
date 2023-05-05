import { createRouter, createWebHistory } from "vue-router";

import EmployeeHome from "../views/employee/EmployeeHome.vue";
import EmployeeForm from "../views/employee/EmployeeForm.vue";
import CustomerHome from "../views/customer/CustomerHome.vue";
import ReportHome from "../views/report/ReportHome.vue";

const routers = [
  {
    path: "/employee",
    component: EmployeeHome,
    name: "EmployeeHomeRouter",
    children: [
      {
        //url sẽ có dạng: employee/id
        path: ":id",
        components: { default: EmployeeHome, EmployeeRouterView: EmployeeForm },
        name: "EmployeeDetailRouter",
        props: true,
      },
      {
        //url sẽ có dạng: employee/create
        path: "create",
        components: { default: EmployeeHome, EmployeeRouterView: EmployeeForm },
        name: "EmployeeCreateRouter",
      },
    ],
  },
  { path: "/customer", component: CustomerHome, name: "CustomerHomeRouter" },
  { path: "/report", component: ReportHome, name: "ReportHomeRouter" },
];

//khởi tạo router:
const router = createRouter({
  history: createWebHistory(),
  routes: routers,
});

export default router;
