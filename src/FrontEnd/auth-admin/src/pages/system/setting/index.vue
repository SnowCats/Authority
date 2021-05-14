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
                        v-model="model.parentValue"
                        :items="dict.items"
                        item.text="text"
                        item.value="value"
                      ></v-select>
                    </v-flex>
                    <v-flex md3 sm6 xs12>
                      <v-text-field label="字典文本" v-model="model.text"></v-text-field>
                    </v-flex>
                    <v-flex md3 sm6 xs12>
                      <v-text-field label="字典值" v-model="model.value"></v-text-field>
                    </v-flex>
                    <v-flex md12 sm12 xs12>
                      <div class="text-right">
                        <v-btn color="green darken-2" class="white--text ma-2" @click="add">
                          <v-icon left>mdi-plus</v-icon>
                          新增
                        </v-btn>
                        <v-btn color="light-blue darken-2" class="white--text ma-2" @click="search">
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
                  :items="list"
                  :page.sync="pagination.page"
                  :items-per-page="pagination.itemsPerPage"
                  hide-default-footer
                  class="elevation-1"
                  @page-count="pagination.count = $event"
                >
                  <template v-slot:[`item.id`]="{ item }">
                    <!-- 序号 -->
                    {{
                      pagination.page *
                        list
                          .map(function (x) {
                            return x.id;
                          })
                          .indexOf(item.id) +
                      1
                    }}
                  </template>
                  <template v-slot:[`item.actions`]="{ item }">
                    <v-icon small class="mr-2" @click="edit(item.id)"> mdi-pencil </v-icon>
                    <v-icon small class="mr-2" @click="del(item.id)"> mdi-delete </v-icon>
                  </template>
                </v-data-table>
                <div class="text-center pt-2">
                  <v-pagination v-model="pagination.page" :length="pagination.count"></v-pagination>
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
import { Vue, Component, Prop } from 'vue-property-decorator';
import Setting from '@/types/system/setting';
import Pagination from '@/types/common/pagination';
import VWidget from '@components/VWidget.vue';
import service from '@/services/system/setting';

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
  // 字典
  private dict = {
    items: [
      {
        value: 0,
        text: '禁用',
      },
      {
        value: 1,
        text: '启用',
      },
    ],
  };
  // 分页
  pagination: Pagination = new Pagination();
  model: any = {
    page: this.pagination.page,
    itemsPerPage: this.pagination.itemsPerPage,
    count: this.pagination.count,
    parentValue: this.setting.parentValue,
    text: this.setting.text,
    value: this.setting.value,
  };
  // Table
  headers: any[] = [
    { text: '序号', value: 'id' },
    { text: '上级字典值', value: 'parentValue' },
    { text: '上级字典文本', value: 'parentText' },
    { text: '字典值', value: 'value' },
    { text: '字典文本', value: 'text' },
    { text: '状态', value: 'status' },
    { text: '备注', value: 'notes' },
    { text: '操作', value: 'actions' },
  ];
  list: Setting[] = [];
  // created
  created(): void {
    this.search();
  }
  // Methods
  // 查询
  search(): void {
    console.log('查询', this.model);
    service.getPagedList(this.model).then((res: any) => {
      this.list = res.data.list;
      console.log('list', this.list);
      this.model.count = res.count;
    });
  }
  // 新增
  add(): void {
    console.log('新增');
    this.$router.push('./setting/add');
  }
  // 编辑
  edit(id: string): void {
    console.log('跳转到编辑');
    this.$router.push('./setting/edit/' + id);
  }
  // 删除
  del(item: string): void {
    console.log('删除', item);
    this.$root.$confirm('Delete?', 'Are you sure?', { color: 'red' })
      .then((value: any) => {
        console.log(value);
    });
  }
}
</script>