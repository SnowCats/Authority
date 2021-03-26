<template>
  <div id="system-setting">
    <div class="page-wrapper">
      <v-container grid-list-xl fluid>
        <v-layout row wrap>
          <v-flex sm12>
            <v-widget title="查询条件">
              <template slot="widget-content">
                <v-container grid-list-xl fluid>
                  <v-layout row wrap>
                    <v-flex md3 sm6 xs12>
                      <v-select
                        label="上级字典值"
                        :clearable="true"
                        v-model="setting.value"
                        :items="item.value.list"
                        item.text="text"
                        item.value="value"
                      ></v-select>
                    </v-flex>
                    <v-flex md3 sm6 xs12>
                      <v-text-field
                        label="字典文本"
                        v-model="setting.text"
                      ></v-text-field>
                    </v-flex>
                    <v-flex md3 sm6 xs12>
                      <v-text-field
                        label="字典值"
                        v-model="setting.value"
                      ></v-text-field>
                    </v-flex>
                    <v-flex md12 sm12 xs12>
                      <div class="text-right">
                        <v-btn
                          color="green darken-2"
                          class="white--text ma-2"
                          @click="add"
                        >
                          <v-icon left>mdi-plus</v-icon>
                          新增
                        </v-btn>
                        <v-btn
                          color="light-blue darken-2"
                          class="white--text ma-2"
                          @click="search"
                        >
                          <v-icon left>mdi-magnify</v-icon>
                          查询
                        </v-btn>
                      </div>
                    </v-flex>
                  </v-layout>
                </v-container>
              </template>
            </v-widget>
            <v-widget title="数据字典列表">
              <template slot="widget-content">
                <v-data-table
                  :headers="headers"
                  :items="desserts"
                  :page.sync="pagination.page"
                  :items-per-page="pagination.itemsPerPage"
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
                    v-model="pagination.page"
                    :length="pagination.pageCount"
                  ></v-pagination>
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
import Setting from "@/types/system/setting";
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
  setting: Setting = new Setting();
  private item = {
    value: {
      list: [
        {
          value: 0,
          text: "禁用",
        },
        {
          value: 1,
          text: "启用",
        },
      ],
    },
  };
  pagination = {
    page: 1,
    pageCount: 0,
    itemsPerPage: 5,
  };
  query = {
    page: 1,
    pageCount: 0,
    itemsPerPage: 5,
    model: {
      text: this.setting.text,
      value: this.setting.value,
    },
  };
  headers: any[] = [
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
  desserts: any[] = [
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
  // 查询
  search(): void {
    console.log("查询");
  }
  // 新增
  add(): void {
    this.$router.push("./setting/add");
    console.log("新增");
  }
  // 编辑
  edit(item: string): void {
    console.log("编辑", item);
  }
  // 删除
  del(item: string): void {
    console.log("删除", item);
  }
}
</script>