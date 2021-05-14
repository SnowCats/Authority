<template>
  <v-dialog
		v-model="dialog"
		:max-width="options.width"
		@keydown.esc="cancel"
		v-bind:style="{ zIndex: options.zIndex }"
	>
		<v-card>
			<v-toolbar dark :color="options.color" dense text>
				<v-toolbar-title class="white--text">{{ title }}</v-toolbar-title>
			</v-toolbar>
			<v-card-text v-show="!!message">{{ message }}</v-card-text>
			<v-card-actions class="pt-0">
				<v-spacer></v-spacer>
				<v-btn color="primary darken-1" @click.native="agree"
					>Yes</v-btn
				>
				<v-btn color="grey" @click.native="cancel">Cancel</v-btn>
			</v-card-actions>
		</v-card>
	</v-dialog>
</template>

<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator'

@Component({})

/**
 * Vuetify Confirm Dialog component
 *
 * Insert component where you want to use it:
 * <confirm ref="confirm"></confirm>
 *
 * Call it:
 * this.$refs.confirm.open('Delete', 'Are you sure?', { color: 'red' }).then((confirm) => {})
 * Or use await:
 * if (await this.$refs.confirm.open('Delete', 'Are you sure?', { color: 'red' })) {
 *   // yes
 * }
 * else {
 *   // cancel
 * }
 *
 * Alternatively you can place it in main App component and access it globally via this.$root.$confirm
 * <template>
 *   <v-app>
 *     ...
 *     <confirm ref="confirm"></confirm>
 *   </v-app>
 * </template>
 *
 * mounted() {
 *   this.$root.$confirm = this.$refs.confirm.open
 * }
 */

export default class VConfirm extends Vue {
  dialog: Boolean = false;
	resolve: any = null;
	reject: any = null;
	message: String = "";
	title: String = "";
  options: any = {
    color: 'primary',
    width: 290,
    zIndex: 10000
  }

	open(title: string, message: string ,options: any): Promise<any> {
		this.dialog = true;
		this.title = title;
		this.message = message;
		this.options = Object.assign(this.options, options);
		return new Promise((resolve: any, reject: any) => {
			this.resolve = resolve;
			this.reject = reject;
		});
	}

	agree(): void {
		this.resolve(true);
		this.dialog = false;
	}

	cancel(): void {
			this.resolve(false);
			this.dialog = false;
		}
}
</script>

<style lang="scss" scoped>

</style>