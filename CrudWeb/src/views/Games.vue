<template>
  <div class="p-6">
    <h1 class="text-2xl font-bold mb-4">Games List</h1>

    <!-- Tombol tambah game -->
    <button
      class="mb-4 bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
      @click="() => handleShowModal('Add Game')"
    >
      Add Game
    </button>

    <!-- Tabel Games -->
    <table class="min-w-full border border-gray-200">
      <thead class="bg-gray-100">
        <tr>
          <th class="py-2 px-4 border-b">ID</th>
          <th class="py-2 px-4 border-b">Title</th>
          <th class="py-2 px-4 border-b">Genre</th>
          <th class="py-2 px-4 border-b">Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="game in games" :key="game.id" class="hover:bg-gray-50">
          <td class="py-2 px-4 border-b">{{ game.id }}</td>
          <td class="py-2 px-4 border-b">{{ game.title }}</td>
          <td class="py-2 px-4 border-b">{{ game.genre?.name }}</td>
          <td class="py-2 px-4 border-b space-x-2">
            <button
              class="bg-green-500 text-white px-2 py-1 rounded hover:bg-green-600"
              @click="() => handleShowModal('Update Game', game)"
            >
              Edit
            </button>
            <button
              class="bg-red-500 text-white px-2 py-1 rounded hover:bg-red-600"
              @click="() => handleDelete(game)"
            >
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- Modal -->
    <Modal :is-open="showModal" :title="modalTitle" @close="showModal = false">
      <GameForm :modal-data @saved="handleSaved" />
    </Modal>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import type { GameType, GameUpdateType } from "../types/game";
import api from "../api/axios";
import type { ApiResponseType } from "../types/api";
import type { PaginateResponseType } from "../types/paginate";
import Modal from "../components/Modal.vue";
import GameForm from "../components/Game/GameForm.vue";

const games = ref<GameType[]>([]);
const showModal = ref(false);
const modalTitle = ref("");
const modalData = ref<GameUpdateType | null>(null);

const fetchData = async () => {
  try {
    const { data } =
      await api.get<ApiResponseType<PaginateResponseType<GameType>>>("/games");
    const items = data.data.items;
    games.value = items;
  } catch (error) {
    console.error("Error fetching games:", error);
  }
};

const handleShowModal = (title: string, data?: GameType) => {
  if (data) {
    modalData.value = {
      id: data.id,
      title: data.title,
      releaseYear: data.releaseYear,
      genreId: data.genre?.id ?? null,
    };
  } else {
    modalData.value = null;
  }

  modalTitle.value = title;
  showModal.value = true;
};

const handleSaved = () => {
  showModal.value = false;
  fetchData();
};

const handleDelete = async (data: GameType) => {
  const confirmDelete = confirm(
    `Are you sure you want to delete ${data.title} game?`,
  );

  if (confirmDelete) {
    try {
      const response = await api.delete<ApiResponseType<null>>(
        "/games/" + data.id,
      );
      const message = response.data.message;
      alert(message);
    } catch (err) {
      alert("Delete game failed");
      console.error(err);
    } finally {
      showModal.value = false;
      fetchData();
    }
  }
};

onMounted(() => {
  fetchData();
});
</script>
