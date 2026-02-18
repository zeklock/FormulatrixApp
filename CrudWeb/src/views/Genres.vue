<template>
  <div class="p-6">
    <h1 class="text-2xl font-bold mb-4">Genre List</h1>

    <!-- Tombol tambah genre -->
    <button
      class="mb-4 bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
    >
      Add Genre
    </button>

    <!-- Tabel Genre -->
    <table class="min-w-full border border-gray-200">
      <thead class="bg-gray-100">
        <tr>
          <th class="py-2 px-4 border-b">ID</th>
          <th class="py-2 px-4 border-b">Name</th>
          <th class="py-2 px-4 border-b">Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="genre in genres" :key="genre.id" class="hover:bg-gray-50">
          <td class="py-2 px-4 border-b">{{ genre.id }}</td>
          <td class="py-2 px-4 border-b">{{ genre.name }}</td>
          <td class="py-2 px-4 border-b space-x-2">
            <button
              class="bg-green-500 text-white px-2 py-1 rounded hover:bg-green-600"
            >
              Edit
            </button>
            <button
              class="bg-red-500 text-white px-2 py-1 rounded hover:bg-red-600"
            >
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import api from "../api/axios";
import type { ApiResponseType } from "../types/api";
import type { PaginateResponseType } from "../types/paginate";
import type { GenreType } from "../types/genre";

const genres = ref<GenreType[]>([]);

const fetchData = async () => {
  try {
    const { data } =
      await api.get<ApiResponseType<PaginateResponseType<GenreType>>>(
        "/genres",
      );
    const items = data.data.items;
    genres.value = items;
  } catch (error) {
    console.error("Error fetching genres:", error);
  }
};

onMounted(() => {
  fetchData();
});
</script>
