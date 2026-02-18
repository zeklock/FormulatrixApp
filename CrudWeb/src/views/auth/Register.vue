<template>
  <div class="flex items-center justify-center h-screen bg-gray-100">
    <div class="bg-white p-8 rounded shadow-md w-full max-w-md">
      <h1 class="text-2xl font-bold mb-6 text-center">Register</h1>

      <form @submit.prevent="handleRegister" class="space-y-4">
        <div>
          <label class="block mb-1 font-medium">First Name</label>
          <input
            type="text"
            v-model="register.firstName"
            required
            class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-green-500"
          />
        </div>

        <div>
          <label class="block mb-1 font-medium">Last Name</label>
          <input
            type="text"
            v-model="register.lastName"
            required
            class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-green-500"
          />
        </div>

        <div>
          <label class="block mb-1 font-medium">Email</label>
          <input
            type="text"
            v-model="register.email"
            required
            class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-green-500"
          />
        </div>

        <div>
          <label class="block mb-1 font-medium">Password</label>
          <input
            type="password"
            v-model="register.password"
            required
            class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-green-500"
          />
        </div>

        <button
          type="submit"
          class="w-full bg-green-500 text-white py-2 rounded hover:bg-green-600 transition"
        >
          Register
        </button>
      </form>

      <p class="mt-4 text-center text-sm">
        Sudah punya akun?
        <router-link to="/login" class="text-green-500 hover:underline"
          >Login</router-link
        >
      </p>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { reactive } from "vue";
import { useRouter } from "vue-router";
import api from "../../api/axios";
import type { RegisterType } from "../../types/auth";

const router = useRouter();
const register = reactive<RegisterType>({
  firstName: "",
  lastName: "",
  email: "",
  password: "",
});

const handleRegister = async () => {
  const { firstName, lastName, email, password } = register;

  try {
    await api.post(
      "/auth/register",
      JSON.stringify({ firstName, lastName, email, password }),
    );
    router.push("/login");
  } catch (err) {
    alert("Register gagal");
    console.error(err);
  }
};
</script>
