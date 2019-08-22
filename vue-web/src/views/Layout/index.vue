<template>
    <div class="MainLayout">
      <!-- <dev_env></dev_env> -->
      <router-view></router-view>
    </div>
</template>

<script>
  // import dev_env from '@/components/Development'
  export default {
    name: 'App',
    data() {
      return {
      }
    },
    computed: {
    },
    // components: {
    //   dev_env
    // },
    created() {
    },
    mounted() {
    },
    methods: {
    }
  }
</script>

<style scoped>
  .MainLayout {
    height: 100%;
    width: 100%;
  }
</style>
