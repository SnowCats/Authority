<template>
  <div id="system-setting">
    <div class="page-wrapper">
      <v-container grid-list-xl fluid>
        <v-layout row wrap>
          <v-flex sm12>
            <v-widget title="数据字典新增">
              <template slot="widget-content">
                <v-container grid-list-xl fluid>
                  <v-layout row wrap>
                    <v-flex md3 sm6 xs12>
                      <v-select
                        label="上级字典值"
                        :clearable="true"
                        v-model="setting"
                        :items="item.value.list"
                        item.text="text"
                        item.value="value"
                      ></v-select>
                    </v-flex>
                    <v-flex md3 sm6 xs12>
                      <v-text-field label="字典值" v-model="setting.value"></v-text-field>
                    </v-flex>
                    <v-flex md3 sm6 xs12>
                      <v-text-field label="字典文本" v-model="setting.text"></v-text-field>
                    </v-flex>
                    <v-flex md12 sm12 xs12>
                      <v-textarea label="备注" v-model="setting.notes"></v-textarea>
                    </v-flex>
                    <v-flex md12 sm12 xs12 class="btns">
                      <v-btn
                        color="green darken-2"
                        class="white--text ma-2"
                        @click="submit()"
                      >
                        <v-icon left>mdi-content-save</v-icon>
                        新增
                      </v-btn>
                      <v-btn
                        color="blue-grey lighten-2"
                        class="white--text ma-2"
                        @click="back()"
                      >
                        <v-icon left>mdi-bookmark-remove</v-icon>
                        返回
                      </v-btn>
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
import Setting from "@/types/system/setting";
import Vue from "vue";
import Component from "vue-class-component";
import VWidget from "../../../components/VWidget.vue";
import $axios from '../../../plugins/axios';

// 组件注入
@Component({
  components: {
    VWidget,
  },
})

// Vue
export default class Index extends Vue {
  // data
  setting: Setting = new Setting();
  private item = {
    value: {
      list: [],
    },
  };

  // Methods
  submit(): void {
    console.log("提交数据");
    $axios.axios.post('/api/Setting/Insert', this.setting).then(res => {
      console.log(res);
    }).catch(function(error) {
      console.log(error.response)
    });
  }
  back(): void {
    // 返回上一级
    this.$router.push(".");
  }
}
</script>

<style lang="scss" scoped>
.btns {
  text-align: center;

  .v-btn {
    margin-right: 15px;
  }
}
</style>