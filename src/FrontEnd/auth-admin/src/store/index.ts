import Vue from 'vue';
import Vuex from 'vuex';

import { Locales } from "@/i18n/locales";
import { defaultLocale } from '@/i18n';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        language: defaultLocale,
        alert: {},
    },
    mutations: {
        setLanguage: (state: any, playload: Locales) => {
            state.language = playload;
        },
    },
    actions: {

    },
    modules: {

    }
});