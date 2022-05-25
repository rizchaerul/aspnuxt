<template>
    <div class="">
        <div class="">
            <div v-if="loading">
                <div
                    class="overlay d-flex align-items-center justify-content-center"
                >
                    <div class="spinner-border" />
                </div>
            </div>

            <div class="d-flex overflow-auto">
                <div
                    v-for="column in table"
                    :key="column.id"
                    class="px-3"
                    style="min-width: 360px; max-width: 360px"
                >
                    <div
                        class="bg-light min-vh-100 p-3 text-black-50 rounded text-left"
                    >
                        <div class="font-weight-bold mb-3">
                            {{ column.title }}
                        </div>

                        <draggable
                            :list="column.tasks"
                            :animation="200"
                            @end="onMove"
                            group="tasks"
                            :id="column.id"
                        >
                            <div
                                v-for="task in column.tasks"
                                :key="task.id"
                                class="shadow-sm bg-white mb-3 rounded p-3"
                                style="cursor: move"
                            >
                                <div class="font-weight-bold mb-3">
                                    {{ task.title }}
                                </div>

                                <div class="d-flex justify-content-between">
                                    <div>
                                        {{
                                            new Date(
                                                task.date
                                            ).toLocaleDateString()
                                        }}
                                    </div>

                                    <div>
                                        {{ task.type }}
                                    </div>
                                </div>
                            </div>
                        </draggable>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style>
@import url("https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css");

.overlay {
    position: fixed;
    width: 100%;
    height: 100%;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: rgba(0, 0, 0, 0.5);
    z-index: 1060;
    cursor: pointer;
}
</style>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import draggable from "vuedraggable";

type Table = Array<{
    id: number;
    title: string;
    tasks: Array<{
        id: number;
        title: string;
        type?: string;
        date: string;
    }>;
}>;

@Component({
    components: { draggable },
    created: async function (this: HelloWorld) {
        await this.fetchData();
    },
})
export default class HelloWorld extends Vue {
    loading = false;

    async fetchData() {
        const result = await fetch("http://localhost:5259/api/Board");

        if (result.ok) {
            this.table = (await result.json()) as Table;
        }
    }

    async onMove(e: any) {
        const newIndex = e.newIndex as number;
        const newCategoryId = parseInt(e.to.id);

        const oldIndex = e.oldIndex as number;
        const oldCategoryId = parseInt(e.from.id);

        if (oldIndex === newIndex && oldCategoryId === newCategoryId) {
            return;
        }

        const tasks =
            this.table.find((c) => c.id === newCategoryId)?.tasks ?? [];
        const id = tasks[newIndex]?.id;

        if (typeof id !== "undefined") {
            this.loading = true;

            // await new Promise((r) => setTimeout(r, 2000));

            const response = await fetch("http://localhost:5259/api/Board", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    columnId: newCategoryId,
                    oldColumnId: oldCategoryId,
                    taskId: id,
                }),
            });

            await this.fetchData();

            this.loading = false;
        }
    }

    table: Table = [];
}
</script>
