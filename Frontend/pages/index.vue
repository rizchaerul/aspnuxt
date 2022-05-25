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
                    v-for="column in columns"
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
                                        {{ task.date }}
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

@Component({
    components: { draggable },
    created: async function (this: HelloWorld) {
        // await this.fetchData();
    },
})
export default class HelloWorld extends Vue {
    loading = false;

    async onMove(a: any) {
        console.log(a.newIndex);
        console.log(a.to.id);

        this.loading = true;
        await new Promise((r) => setTimeout(r, 2000));
        this.loading = false;
    }

    columns = [
        {
            id: 1,
            title: "Backlog",
            tasks: [
                {
                    id: 1,
                    title: "Add discount code to checkout page",
                    date: "Sep 14",
                    type: "Feature Request",
                },
                {
                    id: 2,
                    title: "Provide documentation on integrations",
                    date: "Sep 12",
                },
                {
                    id: 3,
                    title: "Design shopping cart dropdown",
                    date: "Sep 9",
                    type: "Design",
                },
                {
                    id: 4,
                    title: "Add discount code to checkout page",
                    date: "Sep 14",
                    type: "Feature Request",
                },
                {
                    id: 5,
                    title: "Test checkout flow",
                    date: "Sep 15",
                    type: "QA",
                },
            ],
        },
        {
            id: 2,
            title: "In Progress",
            tasks: [
                {
                    id: 6,
                    title: "Design shopping cart dropdown",
                    date: "Sep 9",
                    type: "Design",
                },
                {
                    id: 7,
                    title: "Add discount code to checkout page",
                    date: "Sep 14",
                    type: "Feature Request",
                },
                {
                    id: 8,
                    title: "Provide documentation on integrations",
                    date: "Sep 12",
                    type: "Backend",
                },
            ],
        },
        {
            id: 3,
            title: "Review",
            tasks: [
                {
                    id: 9,
                    title: "Provide documentation on integrations",
                    date: "Sep 12",
                },
                {
                    id: 10,
                    title: "Design shopping cart dropdown",
                    date: "Sep 9",
                    type: "Design",
                },
                {
                    id: 11,
                    title: "Add discount code to checkout page",
                    date: "Sep 14",
                    type: "Feature Request",
                },
                {
                    id: 12,
                    title: "Design shopping cart dropdown",
                    date: "Sep 9",
                    type: "Design",
                },
                {
                    id: 13,
                    title: "Add discount code to checkout page",
                    date: "Sep 14",
                    type: "Feature Request",
                },
            ],
        },
        {
            id: 4,
            title: "Done",
            tasks: [
                {
                    id: 14,
                    title: "Add discount code to checkout page",
                    date: "Sep 14",
                    type: "Feature Request",
                },
                {
                    id: 15,
                    title: "Design shopping cart dropdown",
                    date: "Sep 9",
                    type: "Design",
                },
                {
                    id: 16,
                    title: "Add discount code to checkout page",
                    date: "Sep 14",
                    type: "Feature Request",
                },
            ],
        },
    ];
}
</script>
