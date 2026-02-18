<template>
  <div class="flex items-center justify-center h-screen bg-gray-100">
    <div class="bg-white p-8 rounded shadow-md w-full max-w-md">
      <h1 class="text-2xl font-bold mb-6 text-center">Login</h1>

      <form @submit.prevent="handleLogin" class="space-y-4">
        <div>
          <label class="block mb-1 font-medium">Email</label>
          <input
            type="text"
            v-model="login.email"
            required
            class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>

        <div>
          <label class="block mb-1 font-medium">Password</label>
          <input
            type="password"
            v-model="login.password"
            required
            class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>

        <button
          type="submit"
          class="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 transition"
        >
          Login
        </button>
      </form>

      <p class="mt-4 text-center text-sm">
        Belum punya akun?
        <router-link to="/register" class="text-blue-500 hover:underline"
          >Register</router-link
        >
      </p>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { reactive } from "vue";
import { useRouter } from "vue-router";
import api from "../../api/axios";
import type { ApiResponseType, LoginResponseData } from "../../types/api";
import type { LoginType } from "../../types/auth";

const router = useRouter();
const login = reactive<LoginType>({
  email: "",
  password: "",
});

const handleLogin = async () => {
  const { email, password } = login;

  try {
    const { data } = await api.post<ApiResponseType<LoginResponseData>>(
      "/auth/login",
      JSON.stringify({ email, password }),
    );
    const token = data.data.token;
    localStorage.setItem("token", token);
    router.push("/dashboard");
  } catch (err) {
    alert("Login gagal");
    console.error(err);
  }
};
</script>
