<template>
  <div id="user-add">
    <v-container grid-list-xl fluid>
      <v-layout row wrap>
        <v-flex sm12>
          <v-widget title="新增用户信息">
            <div slot="widget-content">
              <v-layout row>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="姓名" name="name"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-select
                    label="性别"
                    name="gender"
                    :items="items.gender"
                    item-text="text"
                    item-value="value"
                  ></v-select>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="用户名" name="username"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="邮箱" name="email"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="微信" name="wechat"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="手机" name="telephone"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="座机" name="phone"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-select
                    label="岗位"
                    name="gender"
                    :items="items.positions"
                    item-text="name"
                    item-value="id"
                  ></v-select>
                </v-flex>
                <v-flex md3 sm12 xs12>
                    <v-text-field label="地址" name="address"></v-text-field>
                </v-flex>
                <v-flex md12 sm12 xs12>
                    <v-textarea label="备注" name="notes"></v-textarea>
                </v-flex>
                <v-flex md12 sm12 xs12>
                    <v-btn @click="submit()" tile color="success">
                      <v-icon>mdi-content-save-edit</v-icon>保存
                    </v-btn>
                </v-flex>
              </v-layout>
            </div>
          </v-widget>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>
<script>
export default {
  data: () => ({
    items: {
      gender: [
        { value: 0, text: "女" },
        { value: 1, text: "男" },
      ],
      positions: [],
    },
  }),
  created: () => {},
  methods: {
    submit() {},
  },
};
</script>