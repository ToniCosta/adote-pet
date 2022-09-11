import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
import '@mdi/font/css/materialdesignicons.css'

Vue.use(Vuetify);

export default new Vuetify({
  icons: {
    iconfont: 'mdi'
  },
    theme: {
        themes: {
          light: {
            primary: "#9E9E9E",
            secondary: "#FFCDD2",
            accent: "#3F51B5",
            grey: "#9E9E9E",
            redAccent: "#D50000",
            white: "#FFFFFF"
          },
        },
      },
});
