<template>
  <div id="system-setting">
    <div class="page-wrapper">
      <v-container grid-list-xl fluid>
        <v-layout row wrap>
          <v-flex sm12>
            <v-widget title="数据字典查询">
              <template slot="widget-content">
                <v-container grid-list-xl fluid>
                  <v-layout row wrap>
                    <v-flex md3 sm12 xs12>
                      <v-text-field label="姓名"></v-text-field>
                    </v-flex>
                    <v-flex md12 sm12 xs12>
                      <v-toolbar flat>
                        <v-spacer></v-spacer>
                        <v-btn
                          tile
                          color="success"
                          class="white--text"
                          @click="search"
                        >
                          <v-icon left>mdi-magnify</v-icon>
                          查询
                        </v-btn>
                      </v-toolbar>
                    </v-flex>
                  </v-layout>
                </v-container>
              </template>
            </v-widget>
          </v-flex>
        </v-layout>
      </v-container>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({});
</script>

<style scoped>
</style>