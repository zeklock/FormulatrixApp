<template>
  <nav class="p-4 bg-gray-800 text-white flex gap-4">
    <router-link to="/dashboard">Dashboard</router-link>
    <router-link to="/games">Games</router-link>
    <router-link to="/genres">Genres</router-link>
    <template v-if="token">
      <a href="#" @click.prevent="handleLogout">Logout</a>
    </template>
    <template v-else>
      <router-link to="/login">Login</router-link>
      <router-link to="/register">Register</router-link>
    </template>
  </nav>
</template>

<script setup lang="ts">
import { useRouter } from "vue-router";

const router = useRouter();
const token = localStorage.getItem("token");

const handleLogout = () => {
  localStorage.removeItem("token");
  router.push("/login");
};
</script>
