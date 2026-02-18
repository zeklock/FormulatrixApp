<template>
  <form @submit.prevent="handleSubmit" class="space-y-4">
    <div>
      <label class="block mb-1 font-medium">Title</label>
      <input
        type="text"
        v-model="form.title"
        required
        class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
      />
    </div>

    <div>
      <label class="block mb-1 font-medium">Release Year</label>
      <input
        type="text"
        v-model="form.releaseYear"
        required
        class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
      />
    </div>

    <div>
      <label class="block mb-1 font-medium">Genre</label>
      <select
        v-model="form.genreId"
        class="w-full border rounded px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
      >
        <option value="">Select Genre</option>
        <option v-for="genre in genres" :key="genre.id" :value="genre.id">
          {{ genre.name }}
        </option>
      </select>
    </div>

    <button
      type="submit"
      class="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 transition"
    >
      Save
    </button>
  </form>
</template>

<script lang="ts" setup>
import { onMounted, reactive, ref } from "vue";
import api from "../../api/axios";
import type { ApiResponseType } from "../../types/api";
import type { GameCreateType, GameUpdateType } from "../../types/game";
import type { GenreType } from "../../types/genre";
import type { PaginateResponseType } from "../../types/paginate";

const { modalData } = defineProps<{ modalData: GameUpdateType | null }>();

const emits = defineEmits(["saved"]);
const form = reactive<GameCreateType>({
  title: modalData?.title ?? "",
  releaseYear: modalData?.releaseYear ?? new Date().getFullYear(),
  genreId: modalData?.genreId ?? "",
});
const genres = ref<GenreType[]>([]);

const fetchGenre = async () => {
  try {
    const response =
      await api.get<ApiResponseType<PaginateResponseType<GenreType>>>(
        "/genres",
      );
    genres.value = response.data.data.items;
  } catch (err) {
    console.error(err);
  }
};

const handleSubmit = async () => {
  try {
    let message = "";
    form.genreId = form.genreId === "" ? null : form.genreId;

    if (modalData) {
      const response = await api.put<ApiResponseType<GameUpdateType>>(
        "/games/" + modalData.id,
        JSON.stringify(form),
      );
      message = response.data.message;
    } else {
      const response = await api.post<ApiResponseType<GameCreateType>>(
        "/games",
        JSON.stringify(form),
      );
      message = response.data.message;
    }
    emits("saved");
    alert(message);
  } catch (err) {
    alert("Save game failed");
    console.error(err);
  }
};

onMounted(() => {
  fetchGenre();
});
</script>
