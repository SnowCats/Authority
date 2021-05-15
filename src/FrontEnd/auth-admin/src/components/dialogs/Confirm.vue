<template>
	<v-row justify="center">
		<v-dialog
		 	v-model="visible"
		  :max-width="options.width"
			persistent
		>
			<v-card>
				<v-card-title class="headline">
					{{title}}
				</v-card-title>
				<v-card-text>
					{{message}}
				</v-card-text>
				<v-card-actions>
					<v-spacer></v-spacer>
					<v-btn
						:color="options.cancelColor"
						text
						@click.native="cancel"
					>{{options.cancelText}}</v-btn>
					<v-btn
						:color="options.okColor"
						text
						@click.native="agree"
					>{{options.okText}}</v-btn>
				</v-card-actions>
			</v-card>
		</v-dialog>
	</v-row>
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
  visible: Boolean = false;
	message: String = "";
	title: String = "";
  options: any = {
    width: 300,
		okText: 'OK',
		okColor: 'primary',
		cancelText: 'CANCEL',
		cancelColor: 'default',
  };
	resolve: Function = (value: boolean) => value;
	reject: Function = (value: boolean) => value;

	open(title: string, message: string ,options: any): Promise<any> {
		this.visible = true;
		this.title = title;
		this.message = message;
		this.options = Object.assign(this.options, options);
		return new Promise((resolve: Function, reject: Function) => {
			this.resolve = resolve;
			this.reject = reject;
		});
	}

	agree(): void {
		this.resolve(true);
		this.visible = false;
	}

	cancel(): void {
			this.resolve(false);
			this.visible = false;
		}
}
</script>

<style lang="scss" scoped>

</style>