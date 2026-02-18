<template>
  <!-- Overlay -->
  <div
    v-if="isOpen"
    class="fixed inset-0 bg-black/50 bg-opacity-50 flex items-center justify-center z-50"
  >
    <!-- Modal Box -->
    <div class="bg-white rounded-lg shadow-lg w-1/2 max-w-lg">
      <!-- Header -->
      <div class="flex justify-between items-center border-b px-4 py-2">
        <h3 class="text-lg font-semibold">{{ title }}</h3>
        <button
          @click="$emit('close')"
          class="text-gray-500 hover:text-gray-700"
        >
          &times;
        </button>
      </div>

      <!-- Body (dinamis) -->
      <div class="p-4">
        <slot>
          <!-- Default empty content, bisa diisi oleh parent -->
        </slot>
      </div>

      <!-- Footer -->
      <div class="flex justify-end border-t px-4 py-2 space-x-2">
        <button
          @click="$emit('close')"
          class="bg-gray-300 px-3 py-1 rounded hover:bg-gray-400"
        >
          Close
        </button>
        <!-- <button
          @click="$emit('confirm')"
          class="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600"
        >
          Confirm
        </button> -->
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
// Props
defineProps({
  title: { type: String, default: "Modal Title" },
  isOpen: { type: Boolean, default: false },
});
</script>
