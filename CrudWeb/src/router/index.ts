import { createRouter, createWebHistory } from "vue-router";

// Lazy load pages
const Login = () => import("../views/auth/Login.vue");
const Register = () => import("../views/auth/Register.vue");
const Dashboard = () => import("../views/Dashboard.vue");
const Games = () => import("../views/Games.vue");
const Genres = () => import("../views/Genres.vue");

const routes = [
  { path: "/login", component: Login },
  { path: "/register", component: Register },
  { path: "/dashboard", component: Dashboard, meta: { requiresAuth: true } },
  { path: "/games", component: Games, meta: { requiresAuth: true } },
  { path: "/genres", component: Genres, meta: { requiresAuth: true } },
  { path: "/", redirect: "/dashboard" },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

// Navigation guard
router.beforeEach((to, _, next) => {
  const token = localStorage.getItem("token");

  if (to.meta.requiresAuth && !token) {
    next("/login");
  } else if ((to.path === "/login" || to.path === "/register") && token) {
    next("/dashboard");
  } else {
    next();
  }
});

export default router;
