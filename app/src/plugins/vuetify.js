import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';

Vue.use(Vuetify);

export default new Vuetify({
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
