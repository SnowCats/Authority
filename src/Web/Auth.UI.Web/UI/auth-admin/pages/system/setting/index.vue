<template>
    <div id="setting-list">
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
                  <v-text-field label="字典键" name="key"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="字典值" name="value"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="上级字典键" name="parent_key"></v-text-field>
                </v-flex>
                <v-flex md3 sm12 xs12>
                  <v-text-field label="上级字典值" name="parent_value"></v-text-field>
                </v-flex>
                <v-flex md12 sm12 xs12 text-right>
                  <v-btn rounded color="blue" class="white--text"
                    >查询</v-btn
                  >
                </v-flex>
              </v-layout>
            </div>
          </v-widget>
        </v-flex>
        <v-flex sm12>
          <v-widget title="数据字典列表">
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