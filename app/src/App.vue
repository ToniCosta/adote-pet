<template>
  <v-app>
    <MenuApp />
    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
import MenuApp from '@/components/MenuApp'

export default {
  name: 'AppMain',
  components: {
    MenuApp
  },

  data: () => ({
    //
  }),
};
</script>

<style>
.v-tabs-slider-wrapper {
  color: #FF0000;
}

</style>
