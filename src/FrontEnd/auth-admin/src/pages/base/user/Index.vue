<template>
  <div id="base-user">
    <div class="page-wrapper">
      <v-container grid-list-xl fluid>
        <v-layout row wrap>
          <v-flex sm12>
            <v-widget title="用户查询">
              <template slot="widget-content">
                <v-container grid-list-xl fluid>
                  <v-layout row wrap>
                    <v-flex md3 sm12 xs12>
                      <v-text-field label="姓名"></v-text-field>
                    </v-flex>
                    <v-flex md3 sm12 xs12>
                      <v-select
                        label="性别"
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
            <v-widget title="用户列表">
              <template slot="widget-content">
                <v-data-table
                  :headers="headers"
                  :items="desserts"
                  :page.sync="page"
                  :items-per-page="itemsPerPage"
                  hide-default-footer
                  class="elevation-1"
                  @page-count="pageCount = $event"
                >
                  <template v-slot:[`item.actions`]="{ item }">
                    <v-icon small class="mr-2" @click="edit(item)">
                      mdi-pencil
                    </v-icon>
                    <v-icon small class="mr-2" @click="del(item)">
                      mdi-delete
                    </v-icon>
                  </template>
                </v-data-table>
                <div class="text-center pt-2">
                  <v-pagination
                    v-model="page"
                    :length="pageCount"
                  ></v-pagination>
                  <v-text-field
                    :value="itemsPerPage"
                    label="Items per page"
                    type="number"
                    min="-1"
                    max="15"
                    @input="itemsPerPage = parseInt($event, 10)"
                  ></v-text-field>
                </div>
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
import User from "../../../types/base/user";

// 组件注入
@Component({
  components: {
    VWidget,
  },
})

// 用户Vue
export default class Index extends Vue {
  // data
  user: User = new User();
  private item = {
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
  page = 1;
  pageCount = 0;
  itemsPerPage = 10;
  headers = [
    {
      text: "序号",
      align: "start",
      sortable: false,
      value: "name",
    },
    { text: "姓名", value: "calories" },
    { text: "性别", value: "fat" },
    { text: "邮箱", value: "carbs" },
    { text: "手机号", value: "protein" },
    { text: "职位", value: "iron" },
    { text: "操作", value: "actions" },
  ];
  desserts = [
    {
      name: "Frozen Yogurt",
      calories: 159,
      fat: 6.0,
      carbs: 24,
      protein: 4.0,
      iron: "1%",
    },
    {
      name: "Ice cream sandwich",
      calories: 237,
      fat: 9.0,
      carbs: 37,
      protein: 4.3,
      iron: "1%",
    },
    {
      name: "Eclair",
      calories: 262,
      fat: 16.0,
      carbs: 23,
      protein: 6.0,
      iron: "7%",
    },
    {
      name: "Cupcake",
      calories: 305,
      fat: 3.7,
      carbs: 67,
      protein: 4.3,
      iron: "8%",
    },
    {
      name: "Gingerbread",
      calories: 356,
      fat: 16.0,
      carbs: 49,
      protein: 3.9,
      iron: "16%",
    },
    {
      name: "Jelly bean",
      calories: 375,
      fat: 0.0,
      carbs: 94,
      protein: 0.0,
      iron: "0%",
    },
    {
      name: "Lollipop",
      calories: 392,
      fat: 0.2,
      carbs: 98,
      protein: 0,
      iron: "2%",
    },
    {
      name: "Honeycomb",
      calories: 408,
      fat: 3.2,
      carbs: 87,
      protein: 6.5,
      iron: "45%",
    },
    {
      name: "Donut",
      calories: 452,
      fat: 25.0,
      carbs: 51,
      protein: 4.9,
      iron: "22%",
    },
    {
      name: "KitKat",
      calories: 518,
      fat: 26.0,
      carbs: 65,
      protein: 7,
      iron: "6%",
    },
  ];
  // Methods
  edit(item: string): void {
    console.log("编辑", item)
  }
  del(item: string): void {
    console.log("删除", item)
  }
}
</script>