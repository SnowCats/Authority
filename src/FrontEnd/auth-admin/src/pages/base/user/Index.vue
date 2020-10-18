<template>
  <div id="base-user">
    <div class="page-wrapper">
      <v-container grid-list-xl fluid>
        <v-layout row wrap>
          <v-flex sm12>
            <v-widget title="用户信息">
              <template slot="widget-content">
                <v-container grid-list-xl fluid>
                  <v-layout row wrap>
                    <v-flex md3 sm12 xs12>
                      <v-text-field label="姓名"></v-text-field>
                    </v-flex>
                    <v-flex md3 sm12 xs12>
                      <v-select
                        label = "性别"
                        v-model="user.gender"
                        :items="item.gender.list"
                        item.text="text"
                        item.value="value"
                      ></v-select>
                    </v-flex>
                    <v-flex md3 sm12 xs12>
                      <v-text-field label="手机号"></v-text-field>
                    </v-flex>
                    <v-flex md3 sm12 xs12>
                      <v-text-field label="邮箱"></v-text-field>
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
import Component from "vue-class-component";
import VWidget from "../../../components/VWidget.vue";
import UserInfo from '../../../types/base/user';

// 组件注入
@Component({
  components: {
    VWidget,
  },
})
export default class Index extends Vue {
  // data
  user: UserInfo = new UserInfo();
  private item: any = {
    gender: {
      list: [
        {
          value: 0,
          text: "女",
        },
        {
          value: 1,
          text: "男",
        },
      ],
    },
  };
}
</script>