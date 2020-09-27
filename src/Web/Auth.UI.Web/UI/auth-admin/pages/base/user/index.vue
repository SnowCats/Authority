<template>
  <div id="user-list">
    <v-container grid-list-xl fluid>
      <v-layout row wrap>
        <v-flex sm12>
          <v-widget title="查询条件">
            <div slot="widget-header-action">
              <v-btn class="mx-2" fab dark x-small color="indigo accent-4" to="/base/user/add">
                <v-icon dark>mdi-plus</v-icon>
              </v-btn>
            </div>
            <div slot="widget-content">
              <v-layout row>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="姓名"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="邮箱"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="手机"></v-text-field>
                </v-flex>
                <v-flex md12 sm12 xs12 text-right>
                  <v-btn rounded depressed color="blue" class="white--text"
                    >查询</v-btn
                  >
                </v-flex>
              </v-layout>
            </div>
          </v-widget>
        </v-flex>
        <v-flex sm12>
          <v-widget title="用户列表">
            <div slot="widget-content">
              <v-data-table
                :headers="headers"
                :items="users"
                class="elevation-0"
              >
                <template slot="items" slot-scope="props">
                  <td class="text-xs-center">{{ pageIndex * props.index + 1 }}</td>
                  <td class="text-xs-center">{{ props.item.name }}</td>
                  <td class="text-xs-center">
                    <template v-if="props.item.gender === 'Male'">
                      男
                    </template>
                    <template v-else> 女 </template>
                  </td>
                  <td class="text-xs-center">{{ props.item.email }}</td>
                  <td class="text-xs-center">{{ props.item.mobilePhone }}</td>
                  <td class="text-xs-center">
                    <template v-for="role in props.item.roleDatas">
                      {{ role.roleName }}
                    </template>
                  </td>
                  <td class="text-xs-center">
                    <template v-if="props.item.status === 'Enabled'">
                      启用
                    </template>
                    <template v-else> 禁用 </template>
                  </td>
                  <td class="text-xs-center">{{ props.item.notes }}</td>
                  <td class="text-xs-center">
                    <v-btn @click="edit(props.item.id)" flat icon color="grey">
                      <v-icon>edit</v-icon>
                    </v-btn>
                    <v-btn @click="del(props.item.id)" flat icon color="grey">
                      <v-icon>delete</v-icon>
                    </v-btn>
                  </td>
                </template>
              </v-data-table>
              <div text-center>
                <v-pagination v-model="pageIndex" :length="pages"></v-pagination>
              </div>
            </div>
          </v-widget>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>
<script>
import VWidget from "@/components/VWidget";

export default {
  components: {
    VWidget,
  },
  data: () => ({
    pageIndex: 1,
    pageSize: 10,
    pagination: {
      rowsPerPage: null,
      totalItems: null,
    },
    headers: [
      {
        text: "序号",
        align: "center",
        sortable: false,
        value: "id",
      },
      {
        text: "姓名",
        value: "name",
        align: "center",
      },
      {
        text: "性别",
        value: "gender",
        align: "center",
      },
      {
        text: "邮箱",
        value: "email",
        align: "center",
      },
      {
        text: "手机号",
        value: "mobilePhone",
        align: "center",
      },
      {
        text: "所属角色",
        value: "roleDatas",
        align: "center",
      },
      {
        text: "状态",
        value: "status",
        align: "center",
      },
      {
        text: "备注",
        value: "notes",
        align: "center",
      },
      {
        text: "操作",
        value: "action",
        align: "center",
      },
    ],
    users: [],
  }),
  computed: {
    pages() {
      if (
        this.pagination.rowsPerPage == null ||
        this.pagination.totalItems == null
      )
        return 0;
      return Math.ceil(
        this.pagination.totalItems / this.pagination.rowsPerPage
      );
    },
  },
  methods: {
    add: () => {},
    edit: () => {},
    del: (id) => {
      if (confirm("是否删除？")) {
        alert("已删除！");
      }
    },
  },
};
</script>